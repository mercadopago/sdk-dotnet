namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client responsible for managing individual transactions within a payment order.
    /// Supports creating, updating, and deleting transactions via the MercadoPago Orders API
    /// (<c>/v1/orders/{EncodePathParam(id)}/transactions</c>). Update operations are delegated to
    /// <see cref="OrderTransactionUpdateClient"/> internally.
    /// </summary>
    /// <seealso cref="OrderClient"/>
    /// <seealso cref="OrderTransactionUpdateClient"/>
    /// <seealso cref="OrderTransactionRequest"/>
    public class OrderTransactionClient : MercadoPagoClient<OrderTransaction>
    {

        private readonly OrderTransactionUpdateClient transactionUpdateClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderTransactionClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            transactionUpdateClient = new OrderTransactionUpdateClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        public OrderTransactionClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderTransactionClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionClient"/> class.
        /// </summary>
        public OrderTransactionClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Adds a new transaction to an existing order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order ID to add the transaction to.</param>
        /// <param name="request">The transaction data including one or more payments.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the newly created transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/add-transaction-order/post">here</a>.
        /// </remarks>
        public Task<OrderTransaction> CreateAsync(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(id)}/transactions", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Adds a new transaction to an existing order synchronously.
        /// </summary>
        /// <param name="id">The order ID to add the transaction to.</param>
        /// <param name="request">The transaction data including one or more payments.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The newly created transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/add-transaction-order/post">here</a>.
        /// </remarks>
        public OrderTransaction Create(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(id)}/transactions", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Updates the payment details of an existing transaction as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order ID that owns the transaction.</param>
        /// <param name="transactionId">The transaction ID to update.</param>
        /// <param name="request">The updated payment data for the transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the updated transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/update-transaction-order/put">here</a>.
        /// </remarks>
        public Task<OrderUpdateTransaction> UpdateAsync(
            string orderId,
            string transactionId,
            OrderPaymentRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionUpdateClient.UpdateAsync(orderId, transactionId, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates the payment details of an existing transaction synchronously.
        /// </summary>
        /// <param name="orderId">The order ID that owns the transaction.</param>
        /// <param name="transactionId">The transaction ID to update.</param>
        /// <param name="request">The updated payment data for the transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The updated transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/update-transaction-order/put">here</a>.
        /// </remarks>
        public OrderUpdateTransaction Update(
            string orderId,
            string transactionId,
            OrderPaymentRequest request,
            RequestOptions requestOptions = null)
        {
            return transactionUpdateClient.Update(orderId, transactionId, request, requestOptions);
        }

        /// <summary>
        /// Removes a transaction from an order as an asynchronous operation.
        /// </summary>
        /// <param name="oderId">The order ID that owns the transaction.</param>
        /// <param name="transactionId">The transaction ID to delete.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the deleted transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/delete-transaction-order/delete">here</a>.
        /// </remarks>
        public Task<OrderTransaction> DeleteAsync(
            string oderId,
            string transactionId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(oderId)}/transactions/{EncodePathParam(transactionId)}", HttpMethod.DELETE, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Removes a transaction from an order synchronously.
        /// </summary>
        /// <param name="oderId">The order ID that owns the transaction.</param>
        /// <param name="transactionId">The transaction ID to delete.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The deleted transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/delete-transaction-order/delete">here</a>.
        /// </remarks>
        public OrderTransaction Delete(
            string oderId,
            string transactionId,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(oderId)}/transactions/{EncodePathParam(transactionId)}", HttpMethod.DELETE, null, requestOptions);
        }

    }
}
