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
    /// Client for the MercadoPago Payment Refunds API (v1). Handles creating partial or total
    /// refunds for a payment, retrieving individual refunds, and listing all refunds associated
    /// with a payment.
    /// </summary>
    /// <remarks>
    /// Refund operations can also be accessed through <see cref="PaymentClient"/>, which
    /// delegates to this client internally.
    /// </remarks>
    public class PaymentRefundClient : MercadoPagoClient<PaymentRefund>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentRefundClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PaymentRefundClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRefundClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentRefundClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRefundClient"/> class.
        /// </summary>
        public PaymentRefundClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Creates a partial or total refund for a payment asynchronously.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="amount">The amount to refund. If <c>null</c>, the full payment amount is refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> RefundAsync(
            long paymentId,
            decimal? amount,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new PaymentRefundCreateRequest
            {
                Amount = amount,
            };
            return SendAsync(
                $"/v1/payments/{paymentId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a partial or total refund for a payment.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="amount">The amount to refund. If <c>null</c>, the full payment amount is refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund Refund(
            long paymentId,
            decimal? amount,
            RequestOptions requestOptions = null)
        {
            var request = new PaymentRefundCreateRequest
            {
                Amount = amount,
            };
            return Send(
                $"/v1/payments/{paymentId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Creates a total refund for a payment asynchronously, returning the full amount to the payer.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> RefundAsync(
            long paymentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return RefundAsync(paymentId, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a total refund for a payment, returning the full amount to the payer.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The created <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund Refund(
            long paymentId,
            RequestOptions requestOptions = null)
        {
            return Refund(paymentId, null, requestOptions);
        }

        /// <summary>
        /// Retrieves a specific refund by its identifier from a payment asynchronously.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="id">The unique refund identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<PaymentRefund> GetAsync(
            long paymentId,
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/payments/{paymentId}/refunds/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific refund by its identifier from a payment.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="id">The unique refund identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>The <see cref="PaymentRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public PaymentRefund Get(
            long paymentId,
            long id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/payments/{paymentId}/refunds/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Lists all refunds associated with a payment asynchronously.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{T}"/> of <see cref="PaymentRefund"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<ResourcesList<PaymentRefund>> ListAsync(
            long paymentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                $"/v1/payments/{paymentId}/refunds",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists all refunds associated with a payment.
        /// </summary>
        /// <param name="paymentId">The unique payment identifier.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> to customize the request.</param>
        /// <returns>A <see cref="ResourcesList{T}"/> of <see cref="PaymentRefund"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public ResourcesList<PaymentRefund> List(
            long paymentId,
            RequestOptions requestOptions = null)
        {
            return List(
                $"/v1/payments/{paymentId}/refunds",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
