// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents integration metadata for an <see cref="Order"/>, identifying the corporation, application,
    /// integrator, platform, and sponsor involved in the transaction.
    /// </summary>
    public class OrderIntegrationData
    {
        /// <summary>
        /// Identifier of the corporation associated with this integration, used for multi-entity billing scenarios.
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// MercadoPago application identifier that created this order, obtained from the developer dashboard.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Certified integrator identifier assigned by MercadoPago to track third-party integration partners.
        /// </summary>
        public string IntegratorId { get; set; }

        /// <summary>
        /// E-commerce platform identifier (e.g., for WooCommerce, Shopify, or custom platforms) used for analytics.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Sponsor account that receives a share of the transaction fees.
        /// See <see cref="OrderSponsor"/> for the sponsor identifier.
        /// </summary>
        public OrderSponsor Sponsor { get; set; }
    }
}
