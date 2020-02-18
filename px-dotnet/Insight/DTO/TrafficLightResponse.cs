using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class TrafficLightResponse
    {
        [JsonProperty("send-data")]
        public Boolean IsSendDataEnabled { get; set; }

        [JsonProperty("ttl")]
        public Int32 SendTtl { get; set; }

        [JsonProperty("endpoint-whitelist")]
        public List<String> EndpointWhitelist { get; set; }

        [JsonProperty("base64-encode-data")]
        public Boolean IsBase64EncodingEnabled { get; set; }

        public Boolean IsEndpointInWhiteList(String requestUrl) {
            if (this.EndpointWhitelist == null) {
                return false;
            }

            foreach (String pattern in this.EndpointWhitelist) {
                if (pattern.Equals("*")) {
                    return true;
                }

                Boolean matched = true;
                String[] parts = pattern.Split('*');
                foreach (String part in parts) {
                    if (part.Length == 0) {
                        continue;
                    }
                    matched = matched && requestUrl.ToLower().Contains(part);
                }

                if (matched) {
                    return true;
                }
            }

            return false;
        }
    }
}