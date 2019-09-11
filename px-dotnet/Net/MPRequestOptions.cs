using System;
using System.Collections.Generic;
using System.Net;

namespace MercadoPago
{
    /// <summary>
    /// Class with request options 
    /// </summary>
    public class MPRequestOptions
    {
        public String AccessToken { get; set; }

        public int Timeout { get; set; }

        public int Retries { get; set; }

        public IWebProxy Proxy { get; set; }

        public IDictionary<String, String> CustomHeaders { get; set; }

        public MPRequestOptions()
        {
            Timeout = SDK.RequestsTimeout;
            Retries = SDK.RequestsRetries;
            Proxy = SDK.Proxy;
            CustomHeaders = new Dictionary<String, String>();
        }
    }
}