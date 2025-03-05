using System.Collections;

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Payment class.
    /// </summary>       
    public class OrderRefundPaymentRequest
    {
        /// <summary>
        /// Payment amount.
        /// </summary>       
        public IList<OrderRefundTransactionRequest> Transactions { get; set; }

    }

}