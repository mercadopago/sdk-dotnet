namespace MercadoPago.Client.Preapproval
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.PreApproval;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Preapproval (Subscriptions) API (<c>/preapproval</c>).
    /// Provides full CRUD operations on subscriptions and a search endpoint for querying
    /// existing subscriptions with pagination, sorting, and filtering.
    /// </summary>
    public class PreapprovalClient : MercadoPagoClient<Preapproval>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreapprovalClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreapprovalClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreapprovalClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PreapprovalClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreapprovalClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreapprovalClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreapprovalClient"/> class.
        /// </summary>
        public PreapprovalClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a preapproval (subscription) by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the preapproval to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<Preapproval> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a preapproval (subscription) by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the preapproval to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Preapproval Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Creates a new preapproval (subscription) asynchronously.
        /// </summary>
        /// <param name="request">A <see cref="PreapprovalCreateRequest"/> with the subscription data to create.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/subscriptions/_preapproval/post/">here</a>.
        /// </remarks>
        public Task<Preapproval> CreateAsync(
            PreapprovalCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/preapproval", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a new preapproval (subscription) synchronously.
        /// </summary>
        /// <param name="request">A <see cref="PreapprovalCreateRequest"/> with the subscription data to create.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/subscriptions/_preapproval/post/">here</a>.
        /// </remarks>
        public Preapproval Create(
            PreapprovalCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/preapproval", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Updates an existing preapproval (subscription) asynchronously.
        /// Only the properties set in <paramref name="request"/> are modified; unset properties remain unchanged.
        /// </summary>
        /// <param name="id">The unique identifier of the preapproval to update.</param>
        /// <param name="request">A <see cref="PreapprovalUpdateRequest"/> containing the fields to update.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<Preapproval> UpdateAsync(
            string id,
            PreapprovalUpdateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval/{id}", HttpMethod.PUT, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates an existing preapproval (subscription) synchronously.
        /// Only the properties set in <paramref name="request"/> are modified; unset properties remain unchanged.
        /// </summary>
        /// <param name="id">The unique identifier of the preapproval to update.</param>
        /// <param name="request">A <see cref="PreapprovalUpdateRequest"/> containing the fields to update.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The updated <see cref="Preapproval"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Preapproval Update(
            string id,
            PreapprovalUpdateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval/{id}", HttpMethod.PUT, request, requestOptions);
        }

        /// <summary>
        /// Searches for preapprovals (subscriptions) matching the specified criteria asynchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of matching <see cref="Preapproval"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<ResultsResourcesPage<Preapproval>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<Preapproval>>(
                "/preapproval/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for preapprovals (subscriptions) matching the specified criteria synchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A paginated list of matching <see cref="Preapproval"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public ResultsResourcesPage<Preapproval> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<Preapproval>>(
                "/preapproval/search",
                request,
                requestOptions);
        }
    }
}
