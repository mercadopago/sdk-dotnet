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
