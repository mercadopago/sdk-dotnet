// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Request payload for adding a transaction to an existing order via
    /// <c>POST /v1/orders/{id}/transactions</c>. A transaction groups one or more
    /// individual payments that together fulfil the order amount.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    /// <seealso cref="OrderTransactionClient.Create(string, OrderTransactionRequest, RequestOptions)"/>
    /// <seealso cref="OrderPaymentRequest"/>
    public class OrderTransactionRequest : IdempotentRequest
    {
        /// <summary>
        /// List of payments that compose this transaction. Each payment specifies an amount,
        /// payment method, and optional recurring-payment configuration.
        /// </summary>
        /// <seealso cref="OrderPaymentRequest"/>
        public IList<OrderPaymentRequest> Payments { get; set; }
    }

}
