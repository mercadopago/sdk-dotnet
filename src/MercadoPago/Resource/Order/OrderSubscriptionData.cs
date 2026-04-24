// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents subscription billing data for an <see cref="OrderPayment"/>, including the invoice
    /// details, billing cycle, and sequence position within a recurring subscription.
    /// </summary>
    public class OrderSubscriptionData
    {
        /// <summary>
        /// Unique identifier of the invoice generated for this subscription billing cycle.
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// ISO 8601 date when this subscription billing cycle was charged.
        /// </summary>
        public string BillingDate { get; set; }

        /// <summary>
        /// Position of this payment within the subscription lifecycle, indicating the current and total number of payments.
        /// See <see cref="OrderSubscriptionSequence"/>.
        /// </summary>
        public OrderSubscriptionSequence SubscriptionSequence { get; set; }

        /// <summary>
        /// Billing period configuration that defines the recurrence interval for this subscription.
        /// See <see cref="OrderInvoicePeriod"/>.
        /// </summary>
        public OrderInvoicePeriod InvoicePeriod { get; set; }
    }
}
