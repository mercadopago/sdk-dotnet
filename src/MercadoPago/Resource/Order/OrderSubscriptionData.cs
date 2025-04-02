// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Subscription Data class.
    /// </summary>
    public class OrderSubscriptionData
    {
        /// <summary>
        /// Invoice ID.
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Billing Date.
        /// </summary>
        public string BillingDate { get; set; }

        /// <summary>
        /// Subscription Sequence.
        /// </summary>
        public OrderSubscriptionSequence SubscriptionSequence { get; set; }

        /// <summary>
        /// Invoice Period.
        /// </summary>
        public OrderInvoicePeriod InvoicePeriod { get; set; }
    }
}
