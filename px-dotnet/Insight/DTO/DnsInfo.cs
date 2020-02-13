using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class DnsInfo
    {
        [JsonProperty("nameserver-address")]
        public String NameServerAddress { get; set; }

        [JsonProperty("total-lookup-time-millis")]
        public Int64 LookupTime { get; set; }
    }
}