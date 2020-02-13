using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class ProtocolInfo
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("protocol-http")]
        public ProtocolHttp ProtocolHttp { get; set; }

        [JsonProperty("retry-count")]
        public Int32 RetryCount { get; set; }
    }
}