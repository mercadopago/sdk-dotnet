using System;
using System.Net;
using System.Security.Authentication;
using System.Threading;

namespace MercadoPago.Insight
{
    public class MetricsSender
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private SslProtocols? _sslProtocol;
        private Int32 _retries;
        private DateTime _start;
        private DateTime _startRequest;
        private DateTime _endRequest;

        public MetricsSender(
            HttpWebRequest request, 
            HttpWebResponse response, 
            SslProtocols? sslProtocol, 
            Int32 retries, 
            DateTime start, 
            DateTime startRequest, 
            DateTime endRequest)
        {
            _request = request;
            _response = response;
            _sslProtocol = sslProtocol;
            _retries = retries;
            _start = start;
            _startRequest = startRequest;
            _endRequest = endRequest;
        }

        public void Send()
        {
            try
            {
                new Thread(() => {
                    if (InsightDataManager.Instance.IsInsightMetricsEnabled(_request.Address.ToString()))
                    {
                        InsightDataManager.Instance.SendInsightMetrics(_request, _response, _sslProtocol, _retries, _start, _startRequest, _endRequest);
                    }
                }).Start();
            }
            catch (Exception)
            {
                // Do nothing
            }
        }   
    }
}