namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Refund class.
    /// </summary>
    public class OrderRefund
    {
        /// <summary>
        /// Refund ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Reference ID.
        /// </summary>  
        public string referenceId {get; set;}

        /// <summary>
        /// Status Refund.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Amount Refund.
        /// </summary>
        public string Amount { get; set; }
    }
}