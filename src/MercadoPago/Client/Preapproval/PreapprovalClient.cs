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
    /// Client that use the Preapproval APIs.
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
        /// Get async a Preapproval by your ID.
        /// </summary>
        /// <param name="id">The Preapproval ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<Preapproval> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Get a Preapproval by your ID.
        /// </summary>
        /// <param name="id">The Preapproval ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Preapproval Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Creates a Preapproval as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create a Preapproval.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a Preapproval.
        /// </summary>
        /// <param name="request">The data to create a Preapproval.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The created Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Updates a Preapproval as an asynchronous operation.
        /// Just send in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The Preapproval ID.</param>
        /// <param name="request">The data to update the Preapproval.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the updated Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<Preapproval> UpdateAsync(
            string id,
            PreapprovalUpdateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval/{id}", HttpMethod.PUT, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates a Preapproval.
        /// Just send in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The Preapproval ID.</param>
        /// <param name="request">The data to update the Preapproval.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The updated Preapproval.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Preapproval Update(
            string id,
            PreapprovalUpdateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval/{id}", HttpMethod.PUT, request, requestOptions);
        }

        /// <summary>
        /// Searches async for Preapprovals that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is a page of Preapprovals.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Searches for Preapprovals that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A page of Preapprovals.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
