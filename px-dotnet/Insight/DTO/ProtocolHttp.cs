using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class ProtocolHttp
    {
        [JsonProperty("referer-url")]
        public String RefererUrl { get; set; }

        [JsonProperty("request-method")]
        public String RequestMethod { get; set; }

        [JsonProperty("request-url")]
        public String RequestUrl { get; set; }

        [JsonProperty("request-headers")]
        public IDictionary<String, String> RequestHeaders { get; private set; }

        [JsonProperty("response-status-code")]
        public Int32 ResponseCode { get; set; }

        [JsonProperty("response-headers")]
        public IDictionary<String, String> ResponseHeaders { get; private set; }

        [JsonProperty("first-byte-time-millis")]
        public Int64 FirstByteTime { get; set; }

        [JsonProperty("last-byte-time-millis")]
        public Int64 LastByteTime { get; set; }

        [JsonProperty("was-cached")]
        public Boolean WasCached { get; set; }

        public ProtocolHttp()
        {
            this.RequestHeaders = new Dictionary<String, String>();
            this.ResponseHeaders = new Dictionary<String, String>();
        }

        public void AddRequestHeader(String name, String value)
        {
            this.RequestHeaders.Add(name, value);
        }

        public void AddResponseHeader(String name, String value)
        {
            this.ResponseHeaders.Add(name, value);
        }
    }
}