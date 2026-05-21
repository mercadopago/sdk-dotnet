namespace MercadoPago.Client.AuthorizedPayment
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.AuthorizedPayment;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Authorized Payments API (also known as Invoices).
    /// Provides methods to retrieve individual authorized payments and to search for them
    /// with pagination, sorting, and filtering via <see cref="SearchRequest"/>
    /// or <see cref="AdvancedSearchRequest"/>.
    /// </summary>
    public class AuthorizedPaymentClient : MercadoPagoClient<AuthorizedPayment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedPaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public AuthorizedPaymentClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedPaymentClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public AuthorizedPaymentClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedPaymentClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public AuthorizedPaymentClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedPaymentClient"/> class.
        /// </summary>
        public AuthorizedPaymentClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves an authorized payment by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique numeric identifier of the authorized payment to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="AuthorizedPayment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<AuthorizedPayment> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/authorized_payments/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves an authorized payment by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique numeric identifier of the authorized payment to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="AuthorizedPayment"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public AuthorizedPayment Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send($"/authorized_payments/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Searches for authorized payments matching the specified criteria asynchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of matching <see cref="AuthorizedPayment"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<ResultsResourcesPage<AuthorizedPayment>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<AuthorizedPayment>>(
                "/authorized_payments/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for authorized payments matching the specified criteria synchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A paginated list of matching <see cref="AuthorizedPayment"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public ResultsResourcesPage<AuthorizedPayment> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<AuthorizedPayment>>(
                "/authorized_payments/search",
                request,
                requestOptions);
        }
    }
}
