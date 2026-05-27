namespace MercadoPago.Client.DisbursementRefund
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.DisbursementRefund;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Disbursement Refunds API
    /// (<c>/v1/advanced_payments/{id}/refunds</c> and
    /// <c>/v1/advanced_payments/{id}/disbursements/{disbursementId}/refunds</c>).
    /// Enables full and partial refunds of individual disbursements within an
    /// advanced (split) payment.
    /// </summary>
    public class DisbursementRefundClient : MercadoPagoClient<DisbursementRefund>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisbursementRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public DisbursementRefundClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisbursementRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public DisbursementRefundClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisbursementRefundClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public DisbursementRefundClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisbursementRefundClient"/> class.
        /// </summary>
        public DisbursementRefundClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Lists all refunds for an advanced payment asynchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{DisbursementRefund}"/> with all refunds.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<ResourcesList<DisbursementRefund>> ListAllAsync(
            long advancedPaymentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists all refunds for an advanced payment synchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <see cref="ResourcesList{DisbursementRefund}"/> with all refunds.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public ResourcesList<DisbursementRefund> ListAll(
            long advancedPaymentId,
            RequestOptions requestOptions = null)
        {
            return List(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Refunds all disbursements of an advanced payment at once asynchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="request">A <see cref="DisbursementRefundCreateRequest"/> with the refund details applied to every disbursement.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created bulk <see cref="DisbursementRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<DisbursementRefund> CreateAllAsync(
            long advancedPaymentId,
            DisbursementRefundCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refunds all disbursements of an advanced payment at once synchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the advanced payment.</param>
        /// <param name="request">A <see cref="DisbursementRefundCreateRequest"/> with the refund details.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The created bulk <see cref="DisbursementRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public DisbursementRefund CreateAll(
            long advancedPaymentId,
            DisbursementRefundCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/advanced_payments/{advancedPaymentId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Refunds a specific disbursement by amount asynchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the parent advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="request">A <see cref="DisbursementRefundCreateRequest"/> with the refund amount.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="DisbursementRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<DisbursementRefund> CreateAsync(
            long advancedPaymentId,
            long disbursementId,
            DisbursementRefundCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/advanced_payments/{advancedPaymentId}/disbursements/{disbursementId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refunds a specific disbursement by amount synchronously.
        /// </summary>
        /// <param name="advancedPaymentId">The unique identifier of the parent advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="request">A <see cref="DisbursementRefundCreateRequest"/> with the refund amount.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The created <see cref="DisbursementRefund"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public DisbursementRefund Create(
            long advancedPaymentId,
            long disbursementId,
            DisbursementRefundCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/advanced_payments/{advancedPaymentId}/disbursements/{disbursementId}/refunds",
                HttpMethod.POST,
                request,
                requestOptions);
        }
    }
}
