namespace MercadoPago.Resource.MerchantOrder
{
    using System;

    /// <summary>
    /// Represents the estimated delivery date and time window for a <see cref="MerchantOrderShippingOption"/>.
    /// Provides the buyer with an expected delivery range.
    /// </summary>
    public class MerchantOrderShippingEstimatedDelivery
    {
        /// <summary>
        /// Estimated date when the shipment will be delivered.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Start of the estimated delivery time window (e.g., "08:00").
        /// </summary>
        public string TimeFrom { get; set; }

        /// <summary>
        /// End of the estimated delivery time window (e.g., "18:00").
        /// </summary>
        public string TimeTo { get; set; }
    }
}
