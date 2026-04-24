// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the billing period for a subscription invoice within <see cref="OrderSubscriptionData"/>,
    /// defining the recurrence interval and type.
    /// </summary>
    public class OrderInvoicePeriod
    {
        /// <summary>
        /// Billing period type that defines the recurrence unit (e.g., "daily", "monthly", "yearly").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of <see cref="Type"/> units that make up one billing cycle (e.g., 1 for monthly, 3 for quarterly).
        /// </summary>
        public int? Period { get; set; }
    }
}
