// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents an individual processing attempt within an <see cref="OrderPayment"/>,
    /// tracking the result and payment method used for each retry.
    /// </summary>
    public class OrderAttempt
    {
        /// <summary>
        /// Unique identifier assigned to this specific payment processing attempt.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Processing result of this attempt (e.g., "approved", "rejected", "pending").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed explanation of the attempt <see cref="Status"/>, such as a rejection reason code.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Payment method configuration used for this specific attempt.
        /// See <see cref="OrderPaymentMethod"/> for card, ticket, and transfer details.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }
    }
}
