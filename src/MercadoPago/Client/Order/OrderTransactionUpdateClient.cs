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
    public class OrderTransactionUpdateClient : MercadoPagoClient<OrderUpdateTransaction>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTransactionUpdateClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
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
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
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
        /// Update a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// /// <param name="transactionId">The transaction id.</param>
        /// <param name="request">The payment method for the transaction.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the updated ordetransaction.</returns>
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
            return SendAsync($"/v1/orders/{orderId}/transactions/{transactionId}", HttpMethod.PUT, request, requestOptions, cancellationToken);
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
            return Send($"/v1/orders/{orderId}/transactions/{transactionId}", HttpMethod.PUT, request, requestOptions);
        }

    }
}
