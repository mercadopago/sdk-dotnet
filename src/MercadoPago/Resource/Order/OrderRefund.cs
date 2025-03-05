namespace MercadoPago.Resource.Order
{
    using MercadoPago.Http;

    /// <summary>
    /// Transaction class.
    /// </summary>
    public class OrderRefund : IResource
    {
        /// <summary>
        /// Payments information.
        /// </summary>        
        public string Id { get; set; }

        /// <summary>
        /// Payments information.
        /// </summary>        
        public string Status { get; set; }

        /// <summary>
        /// Payments information.
        /// </summary>        
        public string StatusDetail { get; set; }

        /// <summary>
        /// Refunds information.
        /// </summary>
        public OrderTransactionRefund Transactions { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

    }
}