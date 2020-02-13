using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class TcpInfo
    {
        [JsonProperty("source-address")]
        public String SourceAddress { get; set; }

        [JsonProperty("target-address")]
        public String TargetAddress { get; set; }

        [JsonProperty("handshake-time-millis")]
        public Int64 HandshakeTime { get; set; }
    }
}