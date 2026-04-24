// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Subscription-specific metadata for a payment within a recurring billing cycle.
    /// Provides invoice identification, billing dates, and sequencing information.
    /// </summary>
    /// <seealso cref="OrderPaymentRequest"/>
    /// <seealso cref="OrderSubscriptionSequenceRequest"/>
    /// <seealso cref="OrderInvoicePeriodRequest"/>
    public class OrderSubscriptionDataRequest
    {
        /// <summary>
        /// Unique identifier of the invoice associated with this billing cycle.
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Date when the subscription billing occurs (ISO 8601 format).
        /// </summary>
        public string BillingDate { get; set; }

        /// <summary>
        /// Sequence position of this payment within the overall subscription lifecycle
        /// (e.g., payment 3 of 12).
        /// </summary>
        /// <seealso cref="OrderSubscriptionSequenceRequest"/>
        public OrderSubscriptionSequenceRequest SubscriptionSequence { get; set; }

        /// <summary>
        /// Billing period configuration describing the recurrence interval (e.g., monthly).
        /// </summary>
        /// <seealso cref="OrderInvoicePeriodRequest"/>
        public OrderInvoicePeriodRequest InvoicePeriod { get; set; }
    }

}
