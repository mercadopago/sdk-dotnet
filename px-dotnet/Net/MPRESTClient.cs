using MercadoPago.Insight;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

namespace MercadoPago
{
    public class MPRESTClient
    {
        private IWebProxy _proxy;
        private string _proxyHostName;
        private int _proxyPort = -1;

        public string ProxyHostName
        {
            get { return _proxyHostName; }
            set { _proxyHostName = value; }
        }

        public int ProxyPort
        {
            get { return _proxyPort; }
            set { _proxyPort = value; }
        }

        #region Core Methods
        /// <summary>
        /// Class constructor.
        /// </summary>
        public MPRESTClient()
        {
            ServicePointManager.SecurityProtocol |= 
                (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        }

        /// <summary>
        /// Set class variables.
        /// </summary>
        /// <param name="proxyHostName">Proxy host to use.</param>
        /// <param name="proxyPort">Proxy port to use in the proxy host.</param>
        public MPRESTClient(string proxyHostName, int proxyPort)
            : this()
        {
            _proxy = new WebProxy(proxyHostName, proxyPort);
            _proxyHostName = proxyHostName;
            _proxyPort = proxyPort;
        }

        public JToken ExecuteGenericRequest(
            HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload)
        {
            if (SDK.GetAccessToken() != null)
            {
                path = SDK.BaseUrl + path + "?access_token=" + SDK.GetAccessToken();
            }

            MPRequest mpRequest = CreateRequest(httpMethod, path, payloadType, payload, null, 0, 0);

            if (new HttpMethod[] { HttpMethod.POST, HttpMethod.PUT }.Contains(httpMethod))
            {
                Stream requestStream = mpRequest.Request.GetRequestStream();
                requestStream.Write(mpRequest.RequestPayload, 0, mpRequest.RequestPayload.Length);
                requestStream.Close();
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)mpRequest.Request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
                    String StringResponse = reader.ReadToEnd();
                    return JToken.Parse(StringResponse);
                }

            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                Stream dataStream = errorResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
                String StringResponse = reader.ReadToEnd();
                return JToken.Parse(StringResponse);
            }

        }

        /// <summary>
        /// Execute a request to an endpoint.
        /// </summary>
        /// <param name="httpMethod">Method to use in the request.</param>
        /// <param name="path">Endpoint we are pointing.</param>
        /// <param name="payloadType">Type of payload we are sending along with the request.</param>
        /// <param name="payload">The data we are sending.</param>
        /// <param name="colHeaders">Extra headers to send with the request.</param>
        /// <returns>Api response with the result of the call.</returns>
        public MPAPIResponse ExecuteRequest(
            HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload,
            WebHeaderCollection colHeaders,
            int requestTimeout,
            int retries)
        {
            var requestOptions = CreateRequestOptions(colHeaders, requestTimeout, retries);
            return ExecuteRequest(httpMethod, path, payloadType, payload, requestOptions);
        }

        /// <summary>
        /// Core module implementation. Execute a request to an endpoint.
        /// This method is deprecated and will be removed in a future version, please use the
        /// <see cref="ExecuteRequest(HttpMethod, string, PayloadType, JObject, WebHeaderCollection, int, int)" /> method instead.
        /// </summary>
        /// <returns>Api response with the result of the call.</returns>
        // TODO; remove this method in a future major version
        [Obsolete("There is no use for this method.")]
        public MPAPIResponse ExecuteRequestCore(
            HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload,
            WebHeaderCollection colHeaders,
            int connectionTimeout,
            int retries)
        {
            var requestOptions = CreateRequestOptions(colHeaders, connectionTimeout, retries);
            return ExecuteRequest(httpMethod, path, payloadType, payload, requestOptions);
        }

        /// <summary>
        /// Execute a request to an api endpoint.
        /// </summary>
        /// <returns>Api response with the result of the call.</returns>
        public MPAPIResponse ExecuteRequest(
            HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload)
        {
            return ExecuteRequest(httpMethod, path, payloadType, payload, null);
        }

        /// <summary>
        /// Execute a request to an api endpoint.
        /// </summary>
        /// <returns>Api response with the result of the call.</returns>
        public MPAPIResponse ExecuteRequest(
            HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload,
            MPRequestOptions requestOptions)
        {
            DateTime start = DateTime.Now;

            if (requestOptions == null) {
                requestOptions = new MPRequestOptions();
            }

            MPRequest mpRequest = CreateRequest(httpMethod, path, payloadType, payload, requestOptions);

            if (new HttpMethod[] { HttpMethod.POST, HttpMethod.PUT }.Contains(httpMethod))
            {
                using (Stream requestStream = mpRequest.Request.GetRequestStream()) {
                    requestStream.Write(mpRequest.RequestPayload, 0, mpRequest.RequestPayload.Length);
                }
            }

            try
            {               
                Int32 retries;
                DateTime startRequest = DateTime.Now;
                var response = ExecuteRequest(mpRequest.Request, requestOptions.Retries, out retries);
                DateTime endRequest = DateTime.Now;

                // Send metrics
                SendMetrics(mpRequest.Request, response, retries, start, startRequest, endRequest);

                return new MPAPIResponse(httpMethod, mpRequest.Request, payload, response);
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }
        }

        /// <summary>
        /// Create a request to use in the call to a certain endpoint.
        /// </summary>
        /// <returns>Api response with the result of the call.</returns>
        public MPRequest CreateRequest(HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload,
            WebHeaderCollection colHeaders,
            int connectionTimeout,
            int retries)
        {
            var requestOptions = CreateRequestOptions(colHeaders, connectionTimeout, retries);
            return CreateRequest(httpMethod, path, payloadType, payload, requestOptions);
        }

        /// <summary>
        /// Create a request to use in the call to a certain endpoint.
        /// </summary>
        /// <returns>Api response with the result of the call.</returns>
        public MPRequest CreateRequest(HttpMethod httpMethod,
            string path,
            PayloadType payloadType,
            JObject payload,
            MPRequestOptions requestOptions)
        {

            if (string.IsNullOrEmpty(path))
                throw new MPRESTException("Uri can not be an empty string.");

            if (httpMethod.Equals(HttpMethod.GET))
            {
                if (payload != null)
                {
                    throw new MPRESTException("Payload not supported for this method.");
                }
            }
            else if (httpMethod.Equals(HttpMethod.POST))
            {
                //if (payload == null)
                //{
                //    throw new MPRESTException("Must include payload for this method.");
                //}
            }
            else if (httpMethod.Equals(HttpMethod.PUT))
            {
                if (payload == null)
                {
                    throw new MPRESTException("Must include payload for this method.");
                }
            }
            else if (httpMethod.Equals(HttpMethod.DELETE))
            {
                if (payload != null)
                {
                    throw new MPRESTException("Payload not supported for this method.");
                }
            }

            MPRequest mpRequest = new MPRequest();
            mpRequest.Request = (HttpWebRequest)HttpWebRequest.Create(path);
            mpRequest.Request.Method = httpMethod.ToString();

            if (requestOptions == null)
            {
                requestOptions = new MPRequestOptions();
            }

            if (requestOptions.Timeout > 0)
            {
                mpRequest.Request.Timeout = requestOptions.Timeout;
            }

            mpRequest.Request.Headers.Add("x-product-id", SDK.ProductId);
            mpRequest.Request.Headers.Add("x-tracking-id", SDK.TrackingId);

            if (requestOptions.CustomHeaders != null)
            {
                foreach (var header in requestOptions.CustomHeaders)
                {
                    if (mpRequest.Request.Headers[header.Key] == null)
                    {
                        mpRequest.Request.Headers.Add(header.Key, header.Value);
                    }
                }
            }

            if (requestOptions.TrackHeaders != null)
            {
                foreach (var trackHeader in requestOptions.TrackHeaders)
                {
                    if (mpRequest.Request.Headers[trackHeader.Key] == null && trackHeader.Value != null)
                    {
                        mpRequest.Request.Headers[trackHeader.Key] = trackHeader.Value;
                    }
                }
            }

            if (payload != null) // POST & PUT
            {
                byte[] data = null;
                if (payloadType != PayloadType.JSON)
                {
                    var parametersDict = payload.ToObject<Dictionary<string, string>>();
                    StringBuilder parametersString = new StringBuilder();
                    parametersString.Append(string.Format("{0}={1}", parametersDict.First().Key, parametersDict.First().Value));
                    parametersDict.Remove(parametersDict.First().Key);
                    foreach (var value in parametersDict)
                    {
                        parametersString.Append(string.Format("&{0}={1}", value.Key, value.Value.ToString()));
                    }

                    data = Encoding.ASCII.GetBytes(parametersString.ToString());
                }
                else
                {
                    data = Encoding.ASCII.GetBytes(payload.ToString());
                }

                mpRequest.Request.UserAgent = "MercadoPago DotNet SDK/" + SDK.Version;
                mpRequest.Request.ContentLength = data.Length;
                mpRequest.Request.ContentType = payloadType == PayloadType.JSON ? "application/json" : "application/x-www-form-urlencoded";
                mpRequest.RequestPayload = data;
            }

            IWebProxy proxy = requestOptions.Proxy != null ? requestOptions.Proxy : (_proxy != null ? _proxy : SDK.Proxy);
            mpRequest.Request.Proxy = proxy;

            return mpRequest;
        }

        private MPRequestOptions CreateRequestOptions(WebHeaderCollection colHeaders, int connectionTimeout, int retries)
        {
            IDictionary<String, String> headers = new Dictionary<String, String>();
            if (colHeaders != null)
            {
                foreach (var header in colHeaders)
                {
                    headers.Add(header.ToString(), colHeaders[header.ToString()]);
                }
            }

            return new MPRequestOptions
            {
                Timeout = connectionTimeout,
                Retries = retries,
                CustomHeaders = headers
            };
        }

        private HttpWebResponse ExecuteRequest(HttpWebRequest request, Int32 maxRetries, out Int32 retries)
        {
            retries = 0;
            while (true)
            {
                try
                {
                    return (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        return ex.Response as HttpWebResponse;
                    }
                    
                    if (++retries > maxRetries)
                        throw;
                }
            }
        }

        #endregion

        private void SendMetrics(HttpWebRequest request, HttpWebResponse response, int retries, DateTime start, DateTime startRequest, DateTime endRequest)
        {
            try
            {
                var sslProtocol = GetSslProtocol(response.GetResponseStream());
                var metricsSender = new MetricsSender(request, response, sslProtocol, retries, start, startRequest, endRequest);
                metricsSender.Send();
            }
            catch
            {
                // Do nothing
            }
        }

        private SslProtocols? GetSslProtocol(Stream stream)
        {
            if (stream == null)
                return null;

            try
            {
                if (typeof(SslStream).IsAssignableFrom(stream.GetType()))
                {
                    var ssl = stream as SslStream;
                    return ssl.SslProtocol;
                }

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;

                if (stream.GetType().FullName == "System.Net.ConnectStream")
                {
                    var connection = stream.GetType().GetProperty("Connection", flags).GetValue(stream, null);
                    var netStream = connection.GetType().GetProperty("NetworkStream", flags).GetValue(connection, null) as Stream;
                    return GetSslProtocol(netStream);
                }

                if (stream.GetType().FullName == "System.Net.WebRequestStream" || stream.GetType().FullName == "System.Net.WebResponseStream")
                {
                    var connection = stream.GetType().GetProperty("Connection", flags).GetValue(stream, null);
                    var netStream = connection.GetType().GetField("networkStream", flags).GetValue(connection) as Stream;
                    return GetSslProtocol(netStream);
                }

                if (stream.GetType().FullName == "System.Net.TlsStream")
                {
                    var ssl = stream.GetType().GetField("m_Worker", flags).GetValue(stream);
                    if (ssl.GetType().GetProperty("IsAuthenticated", flags).GetValue(ssl, null) as Boolean? != true)
                    {
                        var processAuthMethod = stream.GetType().GetMethod("ProcessAuthentication", flags);
                        processAuthMethod.Invoke(stream, new Object[] { null });
                    }

                    return ssl.GetType().GetProperty("SslProtocol", flags).GetValue(ssl, null) as SslProtocols?;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

