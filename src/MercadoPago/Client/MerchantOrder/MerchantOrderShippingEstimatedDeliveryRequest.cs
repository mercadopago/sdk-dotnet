namespace MercadoPago.Client.MerchantOrder
{
    using System;

    /// <summary>
    /// Estimated delivery window for a merchant order shipment, specifying the expected date
    /// and time range when the package will arrive.
    /// </summary>
    /// <see cref="MerchantOrderShippingOptionRequest"/>
    public class MerchantOrderShippingEstimatedDeliveryRequest
    {
        /// <summary>
        /// Estimated date of delivery.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Earliest expected delivery time on the estimated date (e.g., <c>"09:00"</c>).
        /// </summary>
        public string TimeFrom { get; set; }

        /// <summary>
        /// Latest expected delivery time on the estimated date (e.g., <c>"18:00"</c>).
        /// </summary>
        public string TimeTo { get; set; }
    }
}
