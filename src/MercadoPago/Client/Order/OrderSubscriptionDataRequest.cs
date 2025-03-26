// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Subscription Data class.
    /// </summary>
    public class OrderSubscriptionDataRequest
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
        public OrderSubscriptionSequenceRequest SubscriptionSequence { get; set; }

        /// <summary>
        /// Invoice Period.
        /// </summary>
        public OrderInvoicePeriodRequest InvoicePeriod { get; set; }
    }

}
