// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Payment class.
    /// </summary>
    public class OrderRefundPaymentRequest
    {
        /// <summary>
        /// Transactions.
        /// </summary>
        public IList<OrderRefundTransactionRequest> Transactions { get; set; }

    }

}
