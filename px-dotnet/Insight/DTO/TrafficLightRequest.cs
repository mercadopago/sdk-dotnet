using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class TrafficLightRequest
    {
        [JsonProperty("client-info")]
        public ClientInfo ClientInfo { get; set; }
    }
}