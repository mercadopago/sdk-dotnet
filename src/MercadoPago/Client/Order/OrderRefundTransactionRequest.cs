namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payment class.
    /// </summary>       
    public class OrderRefundTransactionRequest
    {
        /// <summary>
        /// Id.
        /// </summary>       
        public string Id { get; set; }

        /// <summary>
        /// Refund amount.
        /// </summary>       
        public string Amount { get; set; }

    }

}