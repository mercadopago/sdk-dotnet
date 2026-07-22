namespace MercadoPago.Client.PreApprovalPlan
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.PreApprovalPlan;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago PreApproval Plan (Subscription Plans) API
    /// (<c>/preapproval_plan</c>). Provides operations to create, retrieve, update,
    /// and search subscription plan templates that define shared billing terms for
    /// multiple subscriptions.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/subscriptions/create-preapproval-plan/post">here</a>.
    /// </remarks>
    public class PreApprovalPlanClient : MercadoPagoClient<PreApprovalPlan>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreApprovalPlanClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreApprovalPlanClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreApprovalPlanClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PreApprovalPlanClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreApprovalPlanClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreApprovalPlanClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreApprovalPlanClient"/> class.
        /// </summary>
        public PreApprovalPlanClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a subscription plan by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PreApprovalPlan> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval_plan/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a subscription plan by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PreApprovalPlan Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval_plan/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Creates a new subscription plan asynchronously.
        /// </summary>
        /// <param name="request">A <see cref="PreApprovalPlanCreateRequest"/> with the plan data.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PreApprovalPlan> CreateAsync(
            PreApprovalPlanCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/preapproval_plan", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a new subscription plan synchronously.
        /// </summary>
        /// <param name="request">A <see cref="PreApprovalPlanCreateRequest"/> with the plan data.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PreApprovalPlan Create(
            PreApprovalPlanCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/preapproval_plan", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Updates an existing subscription plan asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to update.</param>
        /// <param name="request">A <see cref="PreApprovalPlanUpdateRequest"/> with the fields to modify.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PreApprovalPlan> UpdateAsync(
            string id,
            PreApprovalPlanUpdateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/preapproval_plan/{EncodePathParam(id)}", HttpMethod.PUT, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates an existing subscription plan synchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to update.</param>
        /// <param name="request">A <see cref="PreApprovalPlanUpdateRequest"/> with the fields to modify.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The updated <see cref="PreApprovalPlan"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PreApprovalPlan Update(
            string id,
            PreApprovalPlanUpdateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/preapproval_plan/{EncodePathParam(id)}", HttpMethod.PUT, request, requestOptions);
        }

        /// <summary>
        /// Searches for subscription plans matching the specified criteria asynchronously.
        /// </summary>
        /// <param name="request">Search parameters including filters and pagination.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of matching <see cref="PreApprovalPlan"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<ResultsResourcesPage<PreApprovalPlan>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<PreApprovalPlan>>(
                "/preapproval_plan/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for subscription plans matching the specified criteria synchronously.
        /// </summary>
        /// <param name="request">Search parameters including filters and pagination.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A paginated list of matching <see cref="PreApprovalPlan"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public ResultsResourcesPage<PreApprovalPlan> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<PreApprovalPlan>>(
                "/preapproval_plan/search",
                request,
                requestOptions);
        }
    }
}
