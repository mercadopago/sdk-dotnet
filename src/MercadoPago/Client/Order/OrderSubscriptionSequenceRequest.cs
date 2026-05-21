// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Tracks the position of a payment within a subscription billing sequence.
    /// For example, payment 3 of 12 would have <see cref="Number"/> = 3 and <see cref="Total"/> = 12.
    /// </summary>
    /// <seealso cref="OrderSubscriptionDataRequest"/>
    public class OrderSubscriptionSequenceRequest
    {
        /// <summary>
        /// Current sequence number of this payment in the subscription (e.g., 3 for the third installment).
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Total number of payments in the subscription plan (e.g., 12 for a yearly plan billed monthly).
        /// </summary>
        public int? Total { get; set; }
    }

}
