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
    public class OrderClient : MercadoPagoClient<Order>
    {
        private readonly OrderRefundClient refundClient;

        private readonly OrderTransactionClient transactionClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            refundClient = new OrderRefundClient(httpClient, serializer);
            transactionClient = new OrderTransactionClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public OrderClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        public OrderClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Creates a order as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create a order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/create/post/">here</a>.
        /// </remarks>
        public Task<Order> CreateAsync(
            OrderCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/v1/orders", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a order.
        /// </summary>
        /// <param name="request">The data to create a order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The created order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/pt/reference/order/online-payments/create/post">here</a>.
        /// </remarks>
        public Order Create(
            OrderCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/v1/orders", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Get a order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is an order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/get-order/get">here</a>.
        /// </remarks>
        public Task<Order> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Get a order.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>An order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/get-order/get">here</a>.
        /// </remarks>
        public Order Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Process a order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the processed order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online/process-order/post">here</a>.
        /// </remarks>
        public Task<Order> ProcessAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}/process", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Process a order.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The processed order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online/process-order/post">here</a>.
        /// </remarks>
        public Order Process(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}/process", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Capture a order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the captured order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/capture/post">here</a>.
        /// </remarks>
        public Task<Order> CaptureAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}/capture", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Capture a order.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The captured order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/capture/post">here</a>.
        /// </remarks>
        public Order Capture(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}/capture", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Cancel a order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the canceled order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/cancel-order/post">here</a>.
        /// </remarks>
        public Task<Order> CancelAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}/cancel", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Cancel a order.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The canceled order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/cancel-order/post">here</a>.
        /// </remarks>
        public Order Cancel(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}/cancel", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Refund a order or transaction as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refunded order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/refund/post">here</a>.
        /// </remarks>
        public Task<Order> RefundAsync(
            string id,
            OrderRefundPaymentRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAsync(id, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Refund a order or transaction.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The refunded order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/refund/post">here</a>.
        /// </remarks>
        public Order Refund(
            string id,
            OrderRefundPaymentRequest request = null,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(id, request, requestOptions);
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
        public Task<OrderTransaction> CreateTransactionAsync(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionClient.CreateAsync(id, request, requestOptions, cancellationToken);
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
        public OrderTransaction CreateTransaction(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Create(id, request, requestOptions);
        }

        /// <summary>
        /// Update a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
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
        public Task<OrderUpdateTransaction> UpdateTransactionAsync(
            string id,
            string transactionId,
            OrderPaymentRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionClient.UpdateAsync(id, transactionId, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Update a transaction.
        /// </summary>
        /// <param name="id">The order id.</param>
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
        public OrderUpdateTransaction UpdateTransaction(
            string id,
            string transactionId,
            OrderPaymentRequest request,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Update(id, transactionId, request, requestOptions);
        }

        /// <summary>
        /// Delete a transaction as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/delete-transaction/delete">here</a>.
        /// </remarks>
        public Task<OrderTransaction> DeleteTransactionAsync(
            string id,
            string transactionId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionClient.DeleteAsync(id, transactionId, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Delete a transaction.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="transactionId">The transaction id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/delete-transaction/delete">here</a>.
        /// </remarks>
        public OrderTransaction DeleteTransaction(
            string id,
            string transactionId,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Delete(id, transactionId, requestOptions);
        }

    }
}
