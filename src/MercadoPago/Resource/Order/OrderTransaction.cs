// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

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
