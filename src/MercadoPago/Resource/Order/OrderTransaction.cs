namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Transaction class.
    /// </summary>
    public class OrderTransaction : IResource
    {
        /// <summary>
        /// Payments information.
        /// </summary>        
        public IList<OrderPayment> Payments { get; set; }

        /// <summary>
        /// Refunds information.
        /// </summary>
        public IList<OrderRefundItem> Refunds { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

    }
}