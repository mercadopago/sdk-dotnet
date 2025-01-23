namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Transaction class.
    /// </summary>
    public class OrderTransaction
    {
        /// <summary>
        /// Payments information.
        /// </summary>        
        public IList<OrderPayment> Payments { get; set; }

        /// <summary>
        /// Refunds information.
        /// </summary>
        public IList<OrderRefund> Refunds { get; set; }

    }
}