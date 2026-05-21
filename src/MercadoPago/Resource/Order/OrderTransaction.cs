// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents the transaction container within an <see cref="Order"/>, grouping all payment attempts,
    /// refunds, and chargebacks associated with the order.
    /// </summary>
    public class OrderTransaction : IResource
    {
        /// <summary>
        /// List of <see cref="OrderPayment"/> records representing each payment attempt made against this order.
        /// </summary>
        public IList<OrderPayment> Payments { get; set; }

        /// <summary>
        /// List of <see cref="OrderRefundItem"/> records representing partial or full refunds issued for this order.
        /// </summary>
        public IList<OrderRefundItem> Refunds { get; set; }

        /// <summary>
        /// List of <see cref="OrderChargeback"/> records representing disputes initiated by the payer's financial institution.
        /// </summary>
        public IList<OrderChargeback> Chargebacks { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

    }
}
