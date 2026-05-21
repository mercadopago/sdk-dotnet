// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Defines the billing period for a subscription invoice within an order.
    /// Used together with <see cref="OrderSubscriptionDataRequest"/> to describe recurring billing cycles.
    /// </summary>
    /// <seealso cref="OrderSubscriptionDataRequest"/>
    public class OrderInvoicePeriodRequest
    {
        /// <summary>
        /// Unit of time for the invoice period (e.g., "daily", "monthly", "yearly").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of units that make up the invoice period (e.g., 1 for monthly, 7 for weekly).
        /// </summary>
        public int? Period { get; set; }
    }

}
