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
    /// Client that manages refund operations for advanced payment disbursements.
    /// </summary>
    /// <remarks>
    /// This client handles both full and partial refunds of individual disbursements,
    /// as well as bulk refunds of all disbursements within an advanced payment.
    /// It is typically accessed through <see cref="AdvancedPaymentClient"/> rather than used directly.
    /// </remarks>
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
        /// Initializes a new instance of the <see cref="AdvancedPaymentRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        public AdvancedPaymentRefundClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentRefundClient"/> class.
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
        /// Initializes a new instance of the <see cref="AdvancedPaymentRefundClient"/> class.
        /// </summary>
        public AdvancedPaymentRefundClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Refunds all disbursements of an advanced payment as an asynchronous operation.
        /// Each disbursement will receive a full refund.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment to fully refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the list of refunds created for each disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Refunds all disbursements of an advanced payment.
        /// Each disbursement will receive a full refund.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment to fully refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The list of refunds created for each disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Refunds a specific disbursement of an advanced payment as an asynchronous operation,
        /// optionally for a partial amount.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="amount">The amount to refund. Pass <c>null</c> for a full refund of the disbursement.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Refunds a specific disbursement of an advanced payment, optionally for a partial amount.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="amount">The amount to refund. Pass <c>null</c> for a full refund of the disbursement.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Performs a full refund on a specific disbursement of an advanced payment
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Performs a full refund on a specific disbursement of an advanced payment.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
