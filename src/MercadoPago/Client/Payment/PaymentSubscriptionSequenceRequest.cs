namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Subscription sequence details within <see cref="PaymentTransactionDataRequest"/>.
    /// Tracks the current position within a recurring payment series.
    /// </summary>
    public class PaymentSubscriptionSequenceRequest
    {
        /// <summary>
        /// Current payment number in the subscription sequence (e.g., 3 for the third payment).
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Total number of expected payments in the subscription. <c>null</c> for open-ended subscriptions.
        /// </summary>
        public int? Total { get; set; }
    }
}