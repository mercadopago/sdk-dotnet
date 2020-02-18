using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class EventInfo
    {
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}