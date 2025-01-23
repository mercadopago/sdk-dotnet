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