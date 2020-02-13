using System;
using Newtonsoft.Json;

namespace MercadoPago.Insight.DTO
{
    public class ConnectionInfo
    {
        [JsonProperty("network-type")]
        public String NetworkType { get; set; }

        [JsonProperty("network-speed")]
        public String NetworkSpeed { get; set; }

        [JsonProperty("user-agent")]
        public String UserAgent { get; set; }

        [JsonProperty("was-reused")]
        public Boolean WasReused { get; set; }

        [JsonProperty("dns-info")]
        public DnsInfo DnsInfo { get; set; }

        [JsonProperty("certificate-info")]
        public CertificateInfo CertificateInfo { get; set; }

        [JsonProperty("tcp-info")]
        public TcpInfo TcpInfo { get; set; }

        [JsonProperty("protocol-info")]
        public ProtocolInfo ProtocolInfo { get; set; }

        [JsonProperty("is-complete")]
        public Boolean IsDataComplete { get; set; }
    }   
}