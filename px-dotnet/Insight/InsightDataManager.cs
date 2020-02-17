using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MercadoPago.Insight.DTO;
using Newtonsoft.Json;

namespace MercadoPago.Insight
{
    public sealed class InsightDataManager
    {
        private static readonly String INSIGHT_DEFAULT_BASE_URL = "https://events.mercadopago.com/v2/";
        private static readonly String HEADER_X_INSIGHTS_BUSINESS_FLOW = "X-Insights-Business-Flow";
        private static readonly String HEADER_X_INSIGHTS_METRIC_LAB_SCOPE = "X-Insights-Metric-Lab-Scope";
        private static readonly String HEADER_X_INSIGHTS_DATA_ID = "X-Insights-Data-Id";
        private static readonly String HEADER_X_PRODUCT_ID = "X-Product-Id";
        private static readonly String HEADER_ACCEPT_TYPE = "Accept";
        private static readonly String INSIGHTS_API_ENDPOINT_TRAFFIC_LIGHT = "traffic-light";
        private static readonly String INSIGHTS_API_ENDPOINT_METRIC = "metric";
        private static readonly String HEADER_X_INSIGHTS_EVENT_NAME = "X-Insights-Event-Name";
        private static readonly Int32 DEFAULT_TTL = 600;

        private static InsightDataManager _instance = null;
        private static readonly Object simpleLock = new Object();

        private Int64 _sendDataDeadline = Int64.MinValue;
        public TrafficLightResponse TrafficLight { get; private set; }

        InsightDataManager()
        {
            LoadTrafficLight();
        }

        public static InsightDataManager Instance
        {
            get
            {
                lock (simpleLock)
                {
                    if (_instance == null)
                    {
                        _instance = new InsightDataManager();
                    }
                    return _instance;
                }
            }
        }

        public void SendInsightMetrics(
            HttpWebRequest request, 
            HttpWebResponse response, 
            SslProtocols? sslProtocol, 
            Int32 retries, 
            DateTime start, 
            DateTime startRequest, 
            DateTime endRequest)
        {
            try
            {
                var clientInfo = new ClientInfo
                {
                    Name = SDK.ClientName,
                    Version = SDK.Version,
                };

                var productId = GetHeaderValue(request, HEADER_X_PRODUCT_ID);
                var businessFlow = GetHeaderValue(request, HEADER_X_INSIGHTS_BUSINESS_FLOW);
                BusinessFlowInfo businessFlowInfo = null;
                if (!String.IsNullOrEmpty(productId) || !String.IsNullOrEmpty(businessFlow))
                {
                    businessFlowInfo = new BusinessFlowInfo
                    {
                        Uid = productId,
                        Name = businessFlow,
                    };
                }

                DTO.EventInfo eventInfo = null;
                var eventName = GetHeaderValue(request, HEADER_X_INSIGHTS_EVENT_NAME);
                if (!String.IsNullOrEmpty(eventName))
                {
                    eventInfo = new DTO.EventInfo
                    {
                        Name = eventName,
                    };
                }

                var protocolHttp = new ProtocolHttp
                {
                    RequestUrl = request.Address.ToString(),
                    RequestMethod = request.Method,
                    ResponseCode = (Int32)response.StatusCode,
                    FirstByteTime = startRequest.Subtract(start).Milliseconds,
                    LastByteTime = endRequest.Subtract(startRequest).Milliseconds,
                };

                for (int i = 0; i < request.Headers.Count; i++)
                {
                    var header = request.Headers.GetKey(i);
                    if (header.Equals(HEADER_X_INSIGHTS_DATA_ID, StringComparison.InvariantCultureIgnoreCase)
                        || header.Equals("User-Agent", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    protocolHttp.AddRequestHeader(header, String.Join(";", request.Headers.GetValues(i)));
                }

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    var header = response.Headers.GetKey(i);
                    protocolHttp.AddResponseHeader(header, String.Join(";", response.Headers.GetValues(i)));
                }

                var protocolInfo = new ProtocolInfo
                {
                    Name = "http",
                    ProtocolHttp = protocolHttp,
                    RetryCount = retries,
                };

                var tcpInfo = new TcpInfo
                {
                    SourceAddress = GetHostAddress(),
                    TargetAddress = GetRemoteAddress(request.ServicePoint.Address),
                };

                var connectionInfo = new ConnectionInfo
                {
                    ProtocolInfo = protocolInfo,
                    TcpInfo = tcpInfo,
                    CertificateInfo = GetCertificateInfo(request, sslProtocol),
                    IsDataComplete = endRequest.Subtract(startRequest).Milliseconds > 0,
                };

                if (!String.IsNullOrEmpty(request.UserAgent))
                {
                    connectionInfo.UserAgent = request.UserAgent;
                }

                var deviceInfo = new DeviceInfo
                {
                    OsName = Environment.OSVersion.VersionString,
                };

                var structuredMetricRequest = new StructuredMetricRequest
                {
                    EventInfo = eventInfo,
                    ClientInfo = clientInfo,
                    BusinessFlowInfo = businessFlowInfo,
                    ConnectionInfo = connectionInfo,
                    DeviceInfo = deviceInfo,
                };

                HttpWebResponse httpResponse = PostData(INSIGHTS_API_ENDPOINT_METRIC, structuredMetricRequest);
                httpResponse.Close();
            }
            catch (Exception)
            {
                // Do nothing
            }
        }

        public Boolean IsInsightMetricsEnabled(String url)
        {
            if (DateTime.Now.Ticks > _sendDataDeadline)
            {
                LoadTrafficLight();
            }

            return TrafficLight.IsSendDataEnabled && TrafficLight.IsEndpointInWhiteList(url);
        }

        private void LoadTrafficLight()
        {
            try
            {
                var clientInfo = new ClientInfo
                {
                    Name = SDK.ClientName,
                    Version = SDK.Version,
                };

                var trafficLightRequest = new TrafficLightRequest
                {
                    ClientInfo = clientInfo,
                };

                var httpResponse = PostData(INSIGHTS_API_ENDPOINT_TRAFFIC_LIGHT, trafficLightRequest);
                using (var responseStream = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
                {
                    this.TrafficLight = JsonConvert.DeserializeObject<TrafficLightResponse>(responseStream.ReadToEnd());
                }

                if (this.TrafficLight == null)
                {
                    this.TrafficLight = DefaultTrafficLightResponse();
                }

                _sendDataDeadline = DateTime.Now.Ticks + Math.Abs(this.TrafficLight.SendTtl * 10000000);
            }
            catch (Exception)
            {
                this.TrafficLight = DefaultTrafficLightResponse();
            }
        }

        private TrafficLightResponse DefaultTrafficLightResponse()
        {
            return new TrafficLightResponse
            {
                IsSendDataEnabled = false,
                SendTtl = DEFAULT_TTL,
            };
        }

        private HttpWebResponse PostData(String path, Object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var payload = Encoding.UTF8.GetBytes(json);

            var url = INSIGHT_DEFAULT_BASE_URL + path;

            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.Headers.Add(HEADER_X_INSIGHTS_METRIC_LAB_SCOPE, SDK.MetricsScope);
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Proxy = SDK.Proxy;
            httpRequest.ContentLength = payload.Length;
            httpRequest.Timeout = SDK.RequestsTimeout;

            using (var requestStream = httpRequest.GetRequestStream())
            {
                requestStream.Write(payload, 0, payload.Length);
            }

            return (HttpWebResponse)httpRequest.GetResponse();
        }

        private String GetHeaderValue(HttpWebRequest httpRequest, String header)
        {
            return httpRequest.Headers[header] != null ? httpRequest.Headers[header] : "";
        }

        private String GetHostAddress()
        {
            return GetAddress(() => Dns.GetHostName());
        }

        private String GetRemoteAddress(Uri uri)
        {

            return GetAddress(() => uri.Host);
        }

        private String GetAddress(Func<String> getHostname)
        {
            try
            {
                var host = Dns.GetHostEntry(getHostname());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Do nothing
            }

            return null;
        }

        private CertificateInfo GetCertificateInfo(HttpWebRequest request, SslProtocols? sslProtocol)
        {
            if (request.ServicePoint.Certificate == null)
            {
                return null;
            }

            try
            {
                var certificate = new X509Certificate2(request.ServicePoint.Certificate);
                return new CertificateInfo
                {
                    CertificateType = GetSslProtocolType(sslProtocol),
                    CertificateVersion = GetSslProtocolVersion(sslProtocol),
                    CertificateExpiration = certificate.NotAfter.ToString("yyyy-MM-dd'T'HH:mm"),
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private String GetSslProtocolType(SslProtocols? sslProtocol)
        {
            switch (sslProtocol)
            {
                case SslProtocols.Tls:
                case (SslProtocols)768:
                case (SslProtocols)3072:
                case (SslProtocols)12288:
                    return "TLS";
                case SslProtocols.Ssl2:
                case SslProtocols.Ssl3:
                    return "SSL";
                default:
                    return null;
            }
        }

        private String GetSslProtocolVersion(SslProtocols? sslProtocol)
        {
            switch (sslProtocol)
            {
                case SslProtocols.Tls:
                    return "1";
                case (SslProtocols)768:
                    return "1.1";
                case (SslProtocols)3072:
                    return "1.2";
                case (SslProtocols)12288:
                    return "1.3";
                case SslProtocols.Ssl2:
                    return "2";
                case SslProtocols.Ssl3:
                    return "3";
                default:
                    return null;
            }
        }
    }
}