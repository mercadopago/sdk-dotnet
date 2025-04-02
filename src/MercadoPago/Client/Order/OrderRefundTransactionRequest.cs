// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

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
