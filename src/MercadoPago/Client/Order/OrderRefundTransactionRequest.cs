// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Identifies a single transaction within an order refund request and the amount to refund.
    /// Used inside <see cref="OrderRefundPaymentRequest"/> to perform full or partial refunds
    /// on individual transactions.
    /// </summary>
    /// <seealso cref="OrderRefundPaymentRequest"/>
    public class OrderRefundTransactionRequest
    {
        /// <summary>
        /// Unique identifier of the transaction to refund.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Amount to refund for this transaction, expressed as a decimal string (e.g., "50.00").
        /// If omitted, the full transaction amount is refunded.
        /// </summary>
        public string Amount { get; set; }

    }

}
