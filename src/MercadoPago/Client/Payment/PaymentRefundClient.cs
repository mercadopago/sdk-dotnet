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
    /// Client that use the Payment Refunds APIs.
    /// </summary>
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
        /// Creates async a refund for payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="amount">The amount to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a refund for payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="amount">The amount to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates async a total refund for payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<PaymentRefund> RefundAsync(
            long paymentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return RefundAsync(paymentId, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a total refund for payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public PaymentRefund Refund(
            long paymentId,
            RequestOptions requestOptions = null)
        {
            return Refund(paymentId, null, requestOptions);
        }

        /// <summary>
        /// Gets async a refund by id from the payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="id">The refund ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Gets a refund by id from the payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="id">The refund ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>A task whose the result is the refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Lists async the refunds of the payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the list of refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Lists the refunds of the payment.
        /// </summary>
        /// <param name="paymentId">The payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>A task whose the result is the list of refund.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
