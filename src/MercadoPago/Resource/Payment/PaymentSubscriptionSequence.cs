namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Sequence information for subscription-based or recurring payments,
    /// indicating the current position within the subscription cycle.
    /// Part of <see cref="PaymentTransactionData"/>.
    /// </summary>
    public class PaymentSubscriptionSequence
    {
        /// <summary>
        /// Current sequence number of this payment within the subscription
        /// (e.g., 3 means this is the third payment in the series).
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Total number of payments expected in the subscription cycle.
        /// <c>null</c> if the subscription has no fixed end (open-ended).
        /// </summary>
        public int? Total { get; set; }
    }
}