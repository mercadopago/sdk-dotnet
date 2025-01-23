namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Transaction class.
    /// </summary>
    public class OrderTransactionRequest
    {
        /// <summary>
        /// List of payments.
        /// </summary>
        public IList<OrderPaymentRequest> Payments { get; set; }
    }

}