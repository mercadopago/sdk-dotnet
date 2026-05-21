namespace MercadoPago.Client.AdvancedPayment
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.AdvancedPayment;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that manages Advanced Payment API operations including creation, retrieval,
    /// cancellation, capture, refunds, and release date management.
    /// </summary>
    /// <remarks>
    /// An advanced payment (also known as a split payment) allows a marketplace to distribute
    /// funds from a single buyer across multiple sellers (disbursements). Each disbursement
    /// can specify its own receiver, amount, and fee structure.
    /// </remarks>
    public class AdvancedPaymentClient : MercadoPagoClient<AdvancedPayment>
    {
        private readonly AdvancedPaymentRefundClient refundClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public AdvancedPaymentClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            refundClient = new AdvancedPaymentRefundClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public AdvancedPaymentClient(IHttpClient httpClient)
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
        public AdvancedPaymentClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedPaymentClient"/> class.
        /// </summary>
        public AdvancedPaymentClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves an advanced payment by its ID as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to retrieve.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the advanced payment matching the specified ID.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public Task<AdvancedPayment> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/advanced_payments/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves an advanced payment by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to retrieve.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The advanced payment matching the specified ID.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public AdvancedPayment Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/advanced_payments/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Creates an advanced (split) payment as an asynchronous operation, distributing
        /// funds across the specified disbursement receivers.
        /// </summary>
        /// <param name="request">The data to create the advanced payment, including payer, disbursements, and split payment details.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public Task<AdvancedPayment> CreateAsync(
            AdvancedPaymentCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/v1/advanced_payments",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates an advanced (split) payment, distributing funds across the specified
        /// disbursement receivers.
        /// </summary>
        /// <param name="request">The data to create the advanced payment, including payer, disbursements, and split payment details.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The newly created advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public AdvancedPayment Create(
            AdvancedPaymentCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                "/v1/advanced_payments",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Cancels a pending advanced payment as an asynchronous operation.
        /// Only payments with a pending status can be cancelled.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to cancel.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the cancelled advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPayment> CancelAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new AdvancedPaymentCancelRequest();
            return SendAsync(
                $"/v1/advanced_payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Cancels a pending advanced payment.
        /// Only payments with a pending status can be cancelled.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to cancel.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The cancelled advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPayment Cancel(
            long id,
            RequestOptions requestOptions = null)
        {
            var request = new AdvancedPaymentCancelRequest();
            return Send(
                $"/v1/advanced_payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Captures an authorized advanced payment as an asynchronous operation,
        /// settling the reserved funds with the payment processor.
        /// </summary>
        /// <param name="id">The unique identifier of the authorized advanced payment to capture.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the captured advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPayment> CaptureAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new AdvancedPaymentCaptureRequest();
            return SendAsync(
                $"/v1/advanced_payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Captures an authorized advanced payment, settling the reserved funds
        /// with the payment processor.
        /// </summary>
        /// <param name="id">The unique identifier of the authorized advanced payment to capture.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The captured advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPayment Capture(
            long id,
            RequestOptions requestOptions = null)
        {
            var request = new AdvancedPaymentCaptureRequest();
            return Send(
                $"/v1/advanced_payments/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Updates the money release date for all disbursements of an advanced payment
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="releaseDate">The new date when funds will be released to the sellers.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPayment> UpdateReleaseDateAsync(
            long id,
            DateTime releaseDate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new AdvancedPaymentUpdateReleaseDateRequest
            {
                MoneyReleaseDate = releaseDate,
            };
            return SendAsync(
                $"/v1/advanced_payments/{id}/disburses",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Updates the money release date for all disbursements of an advanced payment.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="releaseDate">The new date when funds will be released to the sellers.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The updated advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPayment UpdateReleaseDate(
            long id,
            DateTime releaseDate,
            RequestOptions requestOptions = null)
        {
            var request = new AdvancedPaymentUpdateReleaseDateRequest
            {
                MoneyReleaseDate = releaseDate,
            };
            return Send(
                $"/v1/advanced_payments/{id}/disburses",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Updates the money release date for a specific disbursement within an advanced payment
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the specific disbursement to update.</param>
        /// <param name="releaseDate">The new date when funds will be released to the seller.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPayment> UpdateReleaseDateAsync(
            long id,
            long disbursementId,
            DateTime releaseDate,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new AdvancedPaymentUpdateReleaseDateRequest
            {
                MoneyReleaseDate = releaseDate,
            };
            return SendAsync(
                $"/v1/advanced_payments/{id}/disbursements/{disbursementId}/disburses",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Updates the money release date for a specific disbursement within an advanced payment.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the specific disbursement to update.</param>
        /// <param name="releaseDate">The new date when funds will be released to the seller.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The updated advanced payment.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPayment UpdateReleaseDate(
            long id,
            long disbursementId,
            DateTime releaseDate,
            RequestOptions requestOptions = null)
        {
            var request = new AdvancedPaymentUpdateReleaseDateRequest
            {
                MoneyReleaseDate = releaseDate,
            };
            return Send(
                $"/v1/advanced_payments/{id}/disbursements/{disbursementId}/disburses",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Searches for advanced payments matching the specified criteria as an asynchronous operation.
        /// </summary>
        /// <param name="request">The search parameters including filters, sorting, and pagination.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of advanced payments matching the search criteria.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public Task<ResultsResourcesPage<AdvancedPayment>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<AdvancedPayment>>(
                "/v1/advanced_payments/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for advanced payments matching the specified criteria.
        /// </summary>
        /// <param name="request">The search parameters including filters, sorting, and pagination.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>A paginated list of advanced payments matching the search criteria.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// </remarks>
        public ResultsResourcesPage<AdvancedPayment> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<AdvancedPayment>>(
                "/v1/advanced_payments/search",
                request,
                requestOptions);
        }

        /// <summary>
        /// Refunds all disbursements of an advanced payment as an asynchronous operation.
        /// Each disbursement will receive a full refund.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to fully refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the list of refunds created for each disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<ResourcesList<AdvancedPaymentDisbursementRefund>> RefundAllAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAllAsync(id, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Refunds all disbursements of an advanced payment.
        /// Each disbursement will receive a full refund.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment to fully refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The list of refunds created for each disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public ResourcesList<AdvancedPaymentDisbursementRefund> RefundAll(
            long id,
            RequestOptions requestOptions = null)
        {
            return refundClient.RefundAll(id, requestOptions);
        }

        /// <summary>
        /// Refunds a specific disbursement of an advanced payment as an asynchronous operation,
        /// optionally for a partial amount.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="amount">The amount to refund. Pass <c>null</c> for a full refund of the disbursement.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPaymentDisbursementRefund> RefundAsync(
            long id,
            long disbursementId,
            decimal? amount,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAsync(
                id, disbursementId, amount, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Refunds a specific disbursement of an advanced payment, optionally for a partial amount.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="amount">The amount to refund. Pass <c>null</c> for a full refund of the disbursement.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPaymentDisbursementRefund Refund(
            long id,
            long disbursementId,
            decimal? amount,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(
                id, disbursementId, amount, requestOptions);
        }

        /// <summary>
        /// Performs a full refund on a specific disbursement of an advanced payment
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<AdvancedPaymentDisbursementRefund> RefundAsync(
            long id,
            long disbursementId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return refundClient.RefundAsync(
                id, disbursementId, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Performs a full refund on a specific disbursement of an advanced payment.
        /// </summary>
        /// <param name="id">The unique identifier of the advanced payment.</param>
        /// <param name="disbursementId">The unique identifier of the disbursement to refund.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The refund details for the disbursement.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public AdvancedPaymentDisbursementRefund Refund(
            long id,
            long disbursementId,
            RequestOptions requestOptions = null)
        {
            return refundClient.Refund(
                id, disbursementId, null, requestOptions);
        }
    }
}
