using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    /**
    * DTO representing Insights Data Client Info
    */
    public class ClientInfo
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("version")]
        public String Version { get; set; }
    }
}