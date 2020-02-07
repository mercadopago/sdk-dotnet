using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    /**
    * DTO representing Insights Data Business Flow Info
    */
    public class BusinessFlowInfo
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("uid")]
        public String Uid { get; set; }
    }
}