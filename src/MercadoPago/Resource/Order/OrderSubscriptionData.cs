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