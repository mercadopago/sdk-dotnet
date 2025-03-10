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