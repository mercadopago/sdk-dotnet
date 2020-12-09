namespace MercadoPago.Client.AdvancedPayment
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.AdvancedPayment;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client with methods to refund advanced payments.
    /// </summary>
    public class AdvancedPaymentRefundClient : MercadoPagoClient<AdvancedPaymentDisbursementRefund>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public AdvancedPaymentRefundClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public AdvancedPaymentRefundClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public AdvancedPaymentRefundClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        public AdvancedPaymentRefundClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Refunds async all disbursements of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refunds list.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<ResourcesList<AdvancedPaymentDisbursementRefund>> RefundAllAsync(
            long advancedPaymentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.POST,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refunds async all disbursements of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A task whose the result is the refunds list.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public ResourcesList<AdvancedPaymentDisbursementRefund> RefundAll(
            long advancedPaymentId,
            RequestOptions requestOptions = null)
        {
            return List(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.POST,
                null,
                requestOptions);
        }

        /// <summary>
        /// Refunds async a disbursement of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="disbursementId">Disbursement ID.</param>
        /// <param name="amount">Amount to be refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refund of the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<AdvancedPaymentDisbursementRefund> RefundAsync(
            long advancedPaymentId,
            long disbursementId,
            decimal? amount,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new AdvancedPaymentRefundCreateRequest
            {
                Amount = amount,
            };
            return SendAsync(
                $"/v1/advanced_payments/{advancedPaymentId}/disbursements/{disbursementId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refunds a disbursement of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="disbursementId">Disbursement ID.</param>
        /// <param name="amount">Amount to be refunded.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The refund of the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public AdvancedPaymentDisbursementRefund Refund(
            long advancedPaymentId,
            long disbursementId,
            decimal? amount,
            RequestOptions requestOptions = null)
        {
            var request = new AdvancedPaymentRefundCreateRequest
            {
                Amount = amount,
            };
            return Send(
                $"/v1/advanced_payments/{advancedPaymentId}/disbursements/{disbursementId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Refunds async a disbursement of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="disbursementId">Disbursement ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refund of the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<AdvancedPaymentDisbursementRefund> RefundAsync(
            long advancedPaymentId,
            long disbursementId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return RefundAsync(
                disbursementId,
                advancedPaymentId,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refunds a disbursement of a advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">Advanced Payment ID.</param>
        /// <param name="disbursementId">Disbursement ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The refund of the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public AdvancedPaymentDisbursementRefund Refund(
            long advancedPaymentId,
            long disbursementId,
            RequestOptions requestOptions = null)
        {
            return Refund(
                disbursementId,
                advancedPaymentId,
                null,
                requestOptions);
        }
    }
}
