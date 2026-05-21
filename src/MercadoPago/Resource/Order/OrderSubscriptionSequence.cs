// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the sequence position of a payment within a subscription lifecycle, as part of
    /// <see cref="OrderSubscriptionData"/>.
    /// </summary>
    public class OrderSubscriptionSequence
    {
        /// <summary>
        /// Current sequence number of this payment within the subscription (e.g., 3 for the third billing cycle).
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Total number of planned payments in the subscription. Null if the subscription has no fixed end date.
        /// </summary>
        public int? Total { get; set; }
    }
}
