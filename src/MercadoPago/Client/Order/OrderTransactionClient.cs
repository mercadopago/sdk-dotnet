namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that use the Order APIs.
    /// </summary>
    public class OrderTransactionClient : MercadoPagoClient<OrderTransaction>
    {

        private readonly OrderTransactionUpdateClient transactionUpdateClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
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
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
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
        /// Create a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created transaction.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/add-transaction/post">here</a>.
        /// </remarks>
        public Task<OrderTransaction> CreateAsync(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}/transactions", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Create a transaction.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The created transaction.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/add-transaction/post">here</a>.
        /// </remarks>
        public OrderTransaction Create(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}/transactions", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Update a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// /// <param name="transactionId">The transaction id.</param>
        /// <param name="request">The order transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the updated transaction.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/update-transaction/put">here</a>.
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
        /// Update a transaction.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
        /// <param name="request">The order transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The updated transaction.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/update-transaction/put">here</a>.
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
        /// Delete a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="oderId">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/delete-transaction/delete">here</a>.
        /// </remarks>
        public Task<OrderTransaction> DeleteAsync(
            string oderId,
            string transactionId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{oderId}/transactions/{transactionId}", HttpMethod.DELETE, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Delete a transaction.
        /// </summary>
        /// <param name="oderId">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/delete-transaction/delete">here</a>.
        /// </remarks>
        public OrderTransaction Delete(
            string oderId,
            string transactionId,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{oderId}/transactions/{transactionId}", HttpMethod.DELETE, null, requestOptions);
        }

    }
}
