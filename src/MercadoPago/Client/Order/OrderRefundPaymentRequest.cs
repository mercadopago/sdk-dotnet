// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Request payload for refunding an order via <c>POST /v1/orders/{id}/refund</c>.
    /// Specifies which transactions to refund and, optionally, the partial amounts.
    /// When sent without a body, a full refund of the entire order is performed.
    /// </summary>
    /// <seealso cref="OrderRefundClient.Refund(string, OrderRefundPaymentRequest, RequestOptions)"/>
    /// <seealso cref="OrderRefundTransactionRequest"/>
    public class OrderRefundPaymentRequest
    {
        /// <summary>
        /// List of transactions to refund. Each entry identifies a transaction and,
        /// optionally, the amount to refund for partial refunds.
        /// </summary>
        /// <seealso cref="OrderRefundTransactionRequest"/>
        public IList<OrderRefundTransactionRequest> Transactions { get; set; }

    }

}
