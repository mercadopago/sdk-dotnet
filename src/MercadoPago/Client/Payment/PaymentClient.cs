namespace MercadoPago.Client.Payment
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Payment;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Payments API (v1). Provides operations to create, retrieve,
    /// cancel, and capture payments, as well as search for payments and manage refunds.
    /// </summary>
    /// <remarks>
    /// This is the primary entry point for payment processing. Refund operations are delegated
    /// internally to <see cref="PaymentRefundClient"/>.
    /// </remarks>
    public class PaymentClient : MercadoPagoClient<Payment>
    {
        private readonly PaymentRefundClient refundClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            refundClient = new PaymentRefundClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PaymentClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentClient"/> class.
        /// </summary>
        public PaymentClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a payment by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request (e.g., access token, custom headers).</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_id/get/">here</a>.
        /// </remarks>
        public Task<Payment> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/payments/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a payment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request (e.g., access token, custom headers).</param>
        /// <returns>The <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_id/get/">here</a>.
        /// </remarks>
        public Payment Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/payments/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Creates a new payment asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="PaymentCreateRequest"/> containing the payment details (payer, amount, payment method, etc.).</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request (e.g., access token, idempotency key, custom headers).</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments/post/">here</a>.
        /// </remarks>
        public Task<Payment> CreateAsync(
            PaymentCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/v1/payments",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a new payment.
        /// </summary>
        /// <param name="request">The <see cref="PaymentCreateRequest"/> containing the payment details (payer, amount, payment method, etc.).</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request (e.g., access token, idempotency key, custom headers).</param>
        /// <returns>The created <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments/post/">here</a>.
        /// </remarks>
        public Payment Create(
            PaymentCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                "/v1/payments",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Cancels a pending payment asynchronously. Only payments with status "pending" can be cancelled.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the cancelled <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<Payment> CancelAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new PaymentCancelRequest();
            return SendAsync(
                $"/v1/payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Cancels a pending payment. Only payments with status "pending" can be cancelled.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The cancelled <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Payment Cancel(
            long id,
            RequestOptions requestOptions = null)
        {
            var request = new PaymentCancelRequest();
            return Send(
                $"/v1/payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Captures an authorized payment for its full amount asynchronously. The payment must have
        /// been created with <c>Capture = false</c> to use this operation.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the captured <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<Payment> CaptureAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return CaptureAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Captures an authorized payment for its full amount. The payment must have been created
        /// with <c>Capture = false</c> to use this operation.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The captured <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Payment Capture(
            long id,
            RequestOptions requestOptions = null)
        {
            return Capture(id, null, requestOptions);
        }

        /// <summary>
        /// Captures an authorized payment asynchronously, optionally for a partial amount. The payment
        /// must have been created with <c>Capture = false</c> to use this operation.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="amount">The amount to capture. If <c>null</c>, the full authorized amount is captured.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the captured <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<Payment> CaptureAsync(
            long id,
            decimal? amount,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new PaymentCaptureRequest
            {
                TransactionAmount = amount,
            };
            return SendAsync(
                $"/v1/payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Captures an authorized payment, optionally for a partial amount. The payment must have
        /// been created with <c>Capture = false</c> to use this operation.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="amount">The amount to capture. If <c>null</c>, the full authorized amount is captured.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The captured <see cref="Payment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Payment Capture(
            long id,
            decimal? amount,
            RequestOptions requestOptions = null)
        {
            var request = new PaymentCaptureRequest
            {
                TransactionAmount = amount,
            };
            return Send(
                $"/v1/payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Searches for payments matching the specified criteria asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchRequest"/> containing filter, sorting, and pagination parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResultsResourcesPage{T}"/> containing the matching payments.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        public Task<ResultsResourcesPage<Payment>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<Payment>>(
                "/v1/payments/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for payments matching the specified criteria.
        /// </summary>
        /// <param name="request">The <see cref="SearchRequest"/> containing filter, sorting, and pagination parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>A <see cref="ResultsResourcesPage{T}"/> containing the matching payments.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        public ResultsResourcesPage<Payment> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<Payment>>(
                "/v1/payments/search",
                request,
                requestOptions);
        }

        /// <summary>
        /// Creates a partial refund for a payment asynchronously. Delegates to <see cref="PaymentRefundClient"/>.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="amount">The amount to refund. If <c>null</c>, the full payment amount is refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> RefundAsync(
            long id,
            decimal? amount,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAsync(id, amount, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a partial refund for a payment. Delegates to <see cref="PaymentRefundClient"/>.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="amount">The amount to refund. If <c>null</c>, the full payment amount is refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund Refund(
            long id,
            decimal? amount,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(id, amount, requestOptions);
        }

        /// <summary>
        /// Creates a total refund for a payment asynchronously. Delegates to <see cref="PaymentRefundClient"/>.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> RefundAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAsync(id, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a total refund for a payment. Delegates to <see cref="PaymentRefundClient"/>.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund Refund(
            long id,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(id, requestOptions);
        }

        /// <summary>
        /// Retrieves a specific refund associated with a payment asynchronously.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="refundId">The unique refund identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> GetRefundAsync(
            long id,
            long refundId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.GetAsync(id, refundId, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific refund associated with a payment.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="refundId">The unique refund identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund GetRefund(
            long paymentId,
            long refundId,
            RequestOptions requestOptions = null)
        {
            return refundClient.Get(paymentId, refundId, requestOptions);
        }

        /// <summary>
        /// Lists all refunds for a payment asynchronously.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{T}"/> of <see cref="PaymentRefund"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<ResourcesList<PaymentRefund>> ListRefundsAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.ListAsync(id, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists all refunds for a payment.
        /// </summary>
        /// <param name="id">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>A <see cref="ResourcesList{T}"/> of <see cref="PaymentRefund"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public ResourcesList<PaymentRefund> ListRefunds(
            long id,
            RequestOptions requestOptions = null)
        {
            return refundClient.List(id, requestOptions);
        }
    }
}
