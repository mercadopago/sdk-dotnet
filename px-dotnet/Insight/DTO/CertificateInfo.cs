using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class CertificateInfo
    {
        [JsonProperty("certificate-type")]
        public String CertificateType { get; set; }

        [JsonProperty("certificate-version")]
        public String CertificateVersion { get; set; }

        [JsonProperty("certificate-expiration")]
        public String CertificateExpiration { get; set; }

        [JsonProperty("handshake-time-millis")]
        public Int64 HandshakeTime { get; set; }
    }
}