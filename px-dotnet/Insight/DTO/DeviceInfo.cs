using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class DeviceInfo
    {
        [JsonProperty("os-name")]
        public String OsName { get; set; }

        [JsonProperty("model-name")]
        public String ModelName { get; set; }

        [JsonProperty("cpu-type")]
        public String CpuType { get; set; }

        [JsonProperty("ram-size")]
        public  String RamSize { get; set; }
    }
}