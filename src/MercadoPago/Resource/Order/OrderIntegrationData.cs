// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Integration data class.
    /// </summary>
    public class OrderIntegrationData
    {
        /// <summary>
        /// Corporation ID.
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Integrator ID.
        /// </summary>
        public string IntegratorId { get; set; }

        /// <summary>
        /// Platform ID.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Sponsor.
        /// </summary>
        public OrderSponsor Sponsor { get; set; }
    }
}
