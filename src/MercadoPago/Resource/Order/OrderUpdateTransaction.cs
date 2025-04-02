// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using MercadoPago.Http;

    /// <summary>
    /// Payment class.
    /// </summary>
    public class OrderUpdateTransaction : IResource
    {

        /// <summary>
        /// Payment Method information.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

    }
}
