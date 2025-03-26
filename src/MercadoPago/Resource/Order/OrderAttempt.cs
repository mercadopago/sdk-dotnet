// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Attempt class.
    /// </summary>
    public class OrderAttempt
    {
        /// <summary>
        /// Attempt ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status detail.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Payment method.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }
    }
}
