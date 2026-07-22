namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Primary client for the MercadoPago Orders API. Provides a unified interface for the
    /// full order lifecycle: creation, retrieval, processing, capture, cancellation, refunds,
    /// transaction management, and search.
    /// Internally delegates to <see cref="OrderRefundClient"/>, <see cref="OrderTransactionClient"/>,
    /// and <see cref="OrderSearchClient"/> for specialized operations.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    /// <seealso cref="OrderRefundClient"/>
    /// <seealso cref="OrderTransactionClient"/>
    public class OrderClient : MercadoPagoClient<Order>
    {
        private readonly OrderRefundClient refundClient;

        private readonly OrderTransactionClient transactionClient;

        private readonly OrderSearchClient searchClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            refundClient = new OrderRefundClient(httpClient, serializer);
            transactionClient = new OrderTransactionClient(httpClient, serializer);
            searchClient = new OrderSearchClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
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
        /// Creates a new payment order as an asynchronous operation.
        /// </summary>
        /// <param name="request">The order creation data including type, amounts, transactions, payer, and items.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the newly created order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/create-order/post/">here</a>.
        /// </remarks>
        public Task<Order> CreateAsync(
            OrderCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/v1/orders", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a new payment order synchronously.
        /// </summary>
        /// <param name="request">The order creation data including type, amounts, transactions, payer, and items.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The newly created order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/pt/reference/online-payments/checkout-api/create-order/post">here</a>.
        /// </remarks>
        public Order Create(
            OrderCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/v1/orders", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Retrieves an existing order by its ID as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the requested order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/get-order/get">here</a>.
        /// </remarks>
        public Task<Order> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves an existing order by its ID synchronously.
        /// </summary>
        /// <param name="id">The order ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The requested order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/get-order/get">here</a>.
        /// </remarks>
        public Order Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Submits an order for payment processing as an asynchronous operation.
        /// The order must have at least one transaction before it can be processed.
        /// </summary>
        /// <param name="id">The order ID to process.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the processed order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/process-order/post">here</a>.
        /// </remarks>
        public Task<Order> ProcessAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(id)}/process", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Submits an order for payment processing synchronously.
        /// The order must have at least one transaction before it can be processed.
        /// </summary>
        /// <param name="id">The order ID to process.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The processed order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/process-order/post">here</a>.
        /// </remarks>
        public Order Process(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(id)}/process", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Captures a previously authorized order as an asynchronous operation.
        /// Only applicable when the order was created with <c>capture_mode</c> set to "manual".
        /// </summary>
        /// <param name="id">The order ID to capture.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the captured order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/capture-order/post">here</a>.
        /// </remarks>
        public Task<Order> CaptureAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(id)}/capture", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Captures a previously authorized order synchronously.
        /// Only applicable when the order was created with <c>capture_mode</c> set to "manual".
        /// </summary>
        /// <param name="id">The order ID to capture.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The captured order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/capture-order/post">here</a>.
        /// </remarks>
        public Order Capture(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(id)}/capture", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Cancels an order as an asynchronous operation. Only orders that have not yet
        /// been fully processed can be canceled.
        /// </summary>
        /// <param name="id">The order ID to cancel.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the canceled order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cancel-order/post">here</a>.
        /// </remarks>
        public Task<Order> CancelAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{EncodePathParam(id)}/cancel", HttpMethod.POST, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Cancels an order synchronously. Only orders that have not yet
        /// been fully processed can be canceled.
        /// </summary>
        /// <param name="id">The order ID to cancel.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The canceled order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cancel-order/post">here</a>.
        /// </remarks>
        public Order Cancel(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{EncodePathParam(id)}/cancel", HttpMethod.POST, null, requestOptions);
        }

        /// <summary>
        /// Refunds an entire order or specific transactions as an asynchronous operation.
        /// Pass a <paramref name="request"/> to target specific transactions for partial refunds,
        /// or omit it to refund the full order.
        /// </summary>
        /// <param name="id">The order ID to refund.</param>
        /// <param name="request">Optional refund details specifying transactions and amounts for partial refunds.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the updated order after the refund.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/refund-order/post">here</a>.
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
        /// Refunds an entire order or specific transactions synchronously.
        /// Pass a <paramref name="request"/> to target specific transactions for partial refunds,
        /// or omit it to refund the full order.
        /// </summary>
        /// <param name="id">The order ID to refund.</param>
        /// <param name="request">Optional refund details specifying transactions and amounts for partial refunds.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The updated order after the refund.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/refund-order/post">here</a>.
        /// </remarks>
        public Order Refund(
            string id,
            OrderRefundPaymentRequest request = null,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(id, request, requestOptions);
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
        public Task<OrderTransaction> CreateTransactionAsync(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionClient.CreateAsync(id, request, requestOptions, cancellationToken);
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
        public OrderTransaction CreateTransaction(
            string id,
            OrderTransactionRequest request,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Create(id, request, requestOptions);
        }

        /// <summary>
        /// Updates the payment details of an existing transaction as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order ID that owns the transaction.</param>
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
        /// Updates the payment details of an existing transaction synchronously.
        /// </summary>
        /// <param name="id">The order ID that owns the transaction.</param>
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
        public OrderUpdateTransaction UpdateTransaction(
            string id,
            string transactionId,
            OrderPaymentRequest request,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Update(id, transactionId, request, requestOptions);
        }

        /// <summary>
        /// Removes a transaction from an order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order ID that owns the transaction.</param>
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
        public Task<OrderTransaction> DeleteTransactionAsync(
            string id,
            string transactionId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return transactionClient.DeleteAsync(id, transactionId, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Removes a transaction from an order synchronously.
        /// </summary>
        /// <param name="id">The order ID that owns the transaction.</param>
        /// <param name="transactionId">The transaction ID to delete.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The deleted transaction.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/delete-transaction-order/delete">here</a>.
        /// </remarks>
        public OrderTransaction DeleteTransaction(
            string id,
            string transactionId,
            RequestOptions requestOptions = null)
        {
            return transactionClient.Delete(id, transactionId, requestOptions);
        }

        /// <summary>
        /// Searches for orders matching the given criteria as an asynchronous operation.
        /// </summary>
        /// <param name="request">The search filters, pagination, and sorting parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the paginated search response containing matching orders.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<OrderSearchResponse> SearchAsync(
            OrderSearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return searchClient.SearchAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Searches for orders matching the given criteria synchronously.
        /// </summary>
        /// <param name="request">The search filters, pagination, and sorting parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The paginated search response containing matching orders.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public OrderSearchResponse Search(
            OrderSearchRequest request,
            RequestOptions requestOptions = null)
        {
            return searchClient.Search(request, requestOptions);
        }

    }
}
