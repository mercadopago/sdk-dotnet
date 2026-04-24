namespace MercadoPago.Client.MerchantOrder
{
    using System.Collections.Generic;

    /// <summary>
    /// Request payload for updating an existing merchant order. This is the top-level DTO sent to the
    /// <see cref="MerchantOrderClient.Update"/> and <see cref="MerchantOrderClient.UpdateAsync"/> methods.
    /// Only the provided fields will be modified; omitted fields remain unchanged.
    /// </summary>
    public class MerchantOrderUpdateRequest
    {
        /// <summary>
        /// MercadoPago site identifier for the country where the order is placed
        /// (e.g., <c>"MLA"</c> for Argentina, <c>"MLB"</c> for Brazil).
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Updated information about the buyer associated with this merchant order.
        /// </summary>
        /// <see cref="MerchantOrderPayerRequest"/>
        public MerchantOrderPayerRequest Payer { get; set; }

        /// <summary>
        /// MercadoPago user ID of the sponsor (integrator) for this order, if applicable.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Updated list of items in the merchant order.
        /// </summary>
        /// <see cref="MerchantOrderItemRequest"/>
        public IList<MerchantOrderItemRequest> Items { get; set; }

        /// <summary>
        /// Updated list of shipments associated with the merchant order.
        /// </summary>
        /// <see cref="MerchantOrderShipmentRequest"/>
        public IList<MerchantOrderShipmentRequest> Shipments { get; set; }

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
