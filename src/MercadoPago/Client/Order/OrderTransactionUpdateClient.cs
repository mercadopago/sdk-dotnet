namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Internal client that handles the HTTP PUT operation for updating a transaction's
    /// payment details via <c>PUT /v1/orders/{EncodePathParam(orderId)}/transactions/{EncodePathParam(transactionId)}</c>.
    /// This client exists because the update response type (<see cref="OrderUpdateTransaction"/>)
    /// differs from the create/delete response type (<see cref="OrderTransaction"/>),
    /// requiring a separate generic base class binding.
    /// Typically accessed indirectly through <see cref="OrderTransactionClient"/>.
    /// </summary>
    /// <seealso cref="OrderTransactionClient"/>
    /// <seealso cref="OrderPaymentRequest"/>
    public class OrderTransactionUpdateClient : MercadoPagoClient<OrderUpdateTransaction>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionUpdateClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderTransactionUpdateClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionUpdateClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        public OrderTransactionUpdateClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionUpdateClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderTransactionUpdateClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionUpdateClient"/> class.
        /// </summary>
        public OrderTransactionUpdateClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Updates a transaction's payment details as an asynchronous operation.
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
            return SendAsync($"/v1/orders/{EncodePathParam(orderId)}/transactions/{EncodePathParam(transactionId)}", HttpMethod.PUT, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates a transaction's payment details synchronously.
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
            return Send($"/v1/orders/{EncodePathParam(orderId)}/transactions/{EncodePathParam(transactionId)}", HttpMethod.PUT, request, requestOptions);
        }

    }
}
