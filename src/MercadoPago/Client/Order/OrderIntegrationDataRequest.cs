// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Integration metadata for an order. Identifies the integrator, platform,
    /// and corporation associated with the integration, as well as any sponsoring
    /// marketplace owner.
    /// </summary>
    public class OrderIntegrationDataRequest
    {
        /// <summary>Identifier of the certified integrator. Type: string.</summary>
        public string IntegratorId { get; set; }

        /// <summary>Platform identifier assigned by MercadoPago. Type: string.</summary>
        public string PlatformId { get; set; }

        /// <summary>Corporation identifier for multi-account setups. Type: string.</summary>
        public string CorporationId { get; set; }

        /// <summary>Sponsor (marketplace owner) information.</summary>
        /// <seealso cref="OrderSponsorRequest"/>
        public OrderSponsorRequest Sponsor { get; set; }
    }
}
