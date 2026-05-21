// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents the response returned when updating a transaction within an <see cref="Order"/>,
    /// containing the updated payment method details.
    /// </summary>
    public class OrderUpdateTransaction : IResource
    {

        /// <summary>
        /// Updated payment method details after the transaction modification.
        /// See <see cref="OrderPaymentMethod"/> for card, ticket, and transfer fields.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

    }
}
