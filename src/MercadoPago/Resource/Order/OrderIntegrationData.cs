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
