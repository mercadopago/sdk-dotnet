namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Payment class.
    /// </summary>
    public class OrderPayment
    {
        /// <summary>
        /// Payment ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Reference ID.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Payment status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Payment status detail.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Payment amount.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Payment Method information.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Automatic Payment information.
        /// </summary>
        public OrderAutomaticPayment AutomaticPayment { get; set; }

        /// <summary>
        /// Stored Credential information.
        /// </summary>
        public OrderStoredCredential StoredCredential { get; set; }

        /// <summary>
        /// Subscription Data information.
        /// </summary>
        public OrderSubscriptionData SubscriptionData { get; set; }

    }
}