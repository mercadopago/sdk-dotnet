namespace MercadoPago.Client.MerchantOrder
{
    using System.Collections.Generic;

    /// <summary>
    /// Request payload for creating a new merchant order. This is the top-level DTO sent to the
    /// <see cref="MerchantOrderClient.Create"/> and <see cref="MerchantOrderClient.CreateAsync"/> methods.
    /// </summary>
    public class MerchantOrderCreateRequest
    {
        /// <summary>
        /// Identifier of the payment preference linked to this merchant order.
        /// Used to associate a pre-configured checkout preference with the order.
        /// </summary>
        public string PreferenceId { get; set; }

        /// <summary>
        /// MercadoPago application identifier that originated this order.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// MercadoPago site identifier for the country where the order is placed
        /// (e.g., <c>"MLA"</c> for Argentina, <c>"MLB"</c> for Brazil).
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Information about the buyer associated with this merchant order.
        /// </summary>
        /// <see cref="MerchantOrderPayerRequest"/>
        public MerchantOrderPayerRequest Payer { get; set; }

        /// <summary>
        /// MercadoPago user ID of the sponsor (integrator) for this order, if applicable.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// List of items included in the merchant order.
        /// </summary>
        /// <see cref="MerchantOrderItemRequest"/>
        public IList<MerchantOrderItemRequest> Items { get; set; }

        /// <summary>
        /// Fully qualified URL (including HTTPS) where IPN payment notifications will be sent.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Free-text field for any supplementary information about the order.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Unique reference identifier in the merchant's own system, used for reconciliation.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Marketplace origin identifier (e.g., <c>"NONE"</c> for direct integrations).
        /// </summary>
        public string Marketplace { get; set; }
    }
}
