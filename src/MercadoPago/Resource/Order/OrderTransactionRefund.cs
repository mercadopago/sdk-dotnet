namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Transaction class.
    /// </summary>
    public class OrderTransactionRefund
    {

        /// <summary>
        /// Refunds information.
        /// </summary>
        public IList<OrderRefundItem> Refunds { get; set; }

    }
}