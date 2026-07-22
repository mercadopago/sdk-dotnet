namespace MercadoPago.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Config;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Serialization;
    using HttpMethod = Http.HttpMethod;

    /// <summary>
    /// Abstract base class for all MercadoPago API client implementations.
    /// Provides the core HTTP request pipeline including serialization, header management,
    /// idempotency key injection, retry strategies, and response parsing.
    /// Each concrete client (e.g., <see cref="Customer.CustomerClient"/>, <see cref="CardToken.CardTokenClient"/>)
    /// extends this class for a specific API resource type.
    /// </summary>
    /// <typeparam name="TResource">
    /// The primary resource type returned by the API endpoints this client wraps.
    /// Must implement <see cref="IResource"/> and provide a parameterless constructor.
    /// </typeparam>
    public abstract class MercadoPagoClient<TResource>
        where TResource : IResource, new()
    {
        private const string ACCEPT_VALUE = "application/json";

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoClient{TResource}"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The HTTP client used to execute requests.
        /// When <c>null</c>, falls back to <see cref="MercadoPagoConfig.HttpClient"/>.
        /// </param>
        /// <param name="serializer">
        /// The serializer used to convert request objects to JSON and to deserialize
        /// API response bodies. When <c>null</c>, falls back to <see cref="MercadoPagoConfig.Serializer"/>.
        /// </param>
        protected MercadoPagoClient(
            IHttpClient httpClient,
            ISerializer serializer)
        {
            HttpClient = httpClient ?? MercadoPagoConfig.HttpClient;
            Serializer = serializer ?? MercadoPagoConfig.Serializer;
        }

        /// <summary>
        /// The <see cref="IHttpClient"/> used to make HTTP requests.
        /// </summary>
        public IHttpClient HttpClient { get; }

        /// <summary>
        /// The <see cref="ISerializer"/> used to serialize request objects
        /// to JSON and deserialize API response to <see cref="IResource"/>.
        /// </summary>
        public ISerializer Serializer { get; }

        /// <summary>
        /// Encodes a dynamic URL path segment before it is interpolated into an endpoint path.
        /// </summary>
        protected static string EncodePathParam(object value)
        {
            return Uri.EscapeDataString(value?.ToString() ?? string.Empty);
        }

        /// <summary>
        /// The default headers sent with every API request, including <c>Accept</c>,
        /// <c>User-Agent</c>, product ID, and tracking ID.
        /// </summary>
        protected IDictionary<string, string> DefaultHeaders =>
            new Dictionary<string, string>
            {
                [Headers.ACCEPT] = ACCEPT_VALUE,
                [Headers.PRODUCT_ID] = MercadoPagoConfig.ProductId,
                [Headers.USER_AGENT] = $"MercadoPago DotNet SDK/{MercadoPagoConfig.Version}",
                [Headers.TRACKING_ID] = MercadoPagoConfig.TrackingId,
            };

        /// <summary>
        /// Sends an asynchronous HTTP request to the specified API endpoint and
        /// deserializes the response into <typeparamref name="TResource"/>.
        /// For POST/PUT requests the <paramref name="request"/> is serialized as a JSON body;
        /// for GET requests it is serialized as query-string parameters.
        /// </summary>
        /// <param name="path">Relative path appended to <see cref="MercadoPagoConfig.BaseUrl"/> (e.g., <c>"/v1/payments"</c>).</param>
        /// <param name="httpMethod">The HTTP method to use (GET, POST, PUT, DELETE).</param>
        /// <param name="request">
        /// Request payload. Serialized as JSON body for POST/PUT, or as query-string for GET.
        /// Pass <c>null</c> when no body or parameters are needed.
        /// </param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task whose result is the deserialized <typeparamref name="TResource"/> from the API response.
        /// </returns>
        protected Task<TResource> SendAsync(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync<TResource>(
                path,
                httpMethod,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Sends a synchronous HTTP request to the specified API endpoint and
        /// deserializes the response into <typeparamref name="TResource"/>.
        /// This is a blocking wrapper around <see cref="SendAsync"/>.
        /// </summary>
        /// <param name="path">Relative path appended to <see cref="MercadoPagoConfig.BaseUrl"/> (e.g., <c>"/v1/payments"</c>).</param>
        /// <param name="httpMethod">The HTTP method to use (GET, POST, PUT, DELETE).</param>
        /// <param name="request">
        /// Request payload. Serialized as JSON body for POST/PUT, or as query-string for GET.
        /// Pass <c>null</c> when no body or parameters are needed.
        /// </param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The deserialized <typeparamref name="TResource"/> from the API response.</returns>
        protected TResource Send(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null)
        {
            return SendAsync(path, httpMethod, request, requestOptions, default)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a list of resources asynchronously from the specified API endpoint.
        /// The response is deserialized into a <see cref="ResourcesList{TResource}"/>.
        /// </summary>
        /// <param name="path">Relative API path that returns an array of resources (e.g., <c>"/v1/customers/{id}/cards"</c>).</param>
        /// <param name="httpMethod">The HTTP method to use (typically GET).</param>
        /// <param name="request">Optional request payload or query parameters. Pass <c>null</c> when not needed.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task whose result is a <see cref="ResourcesList{TResource}"/> containing the items returned by the API.
        /// </returns>
        protected Task<ResourcesList<TResource>> ListAsync(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync<ResourcesList<TResource>>(
                path,
                httpMethod,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of resources synchronously from the specified API endpoint.
        /// This is a blocking wrapper around <see cref="ListAsync"/>.
        /// </summary>
        /// <param name="path">Relative API path that returns an array of resources (e.g., <c>"/v1/customers/{id}/cards"</c>).</param>
        /// <param name="httpMethod">The HTTP method to use (typically GET).</param>
        /// <param name="request">Optional request payload or query parameters. Pass <c>null</c> when not needed.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>
        /// A <see cref="ResourcesList{TResource}"/> containing the items returned by the API.
        /// </returns>
        protected ResourcesList<TResource> List(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null)
        {
            return SendAsync<ResourcesList<TResource>>(
                path,
                httpMethod,
                request,
                requestOptions,
                default)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a paginated search asynchronously against the specified search endpoint
        /// and returns a page of matching resources.
        /// Search parameters from <paramref name="request"/> are serialized as query-string arguments.
        /// </summary>
        /// <typeparam name="TPageResult">
        /// The page result type (e.g., <c>ResultsResourcesPage&lt;T&gt;</c>) that implements
        /// <see cref="IResourcesPage{TResource}"/>.
        /// </typeparam>
        /// <param name="path">Relative search endpoint path (e.g., <c>"/v1/customers/search"</c>).</param>
        /// <param name="request">
        /// A <see cref="SearchRequest"/> (or <see cref="AdvancedSearchRequest"/>) containing
        /// pagination, filter, sorting, and date-range parameters.
        /// </param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task whose result is a <typeparamref name="TPageResult"/> containing the matched resources and paging metadata.
        /// </returns>
        protected Task<TPageResult> SearchAsync<TPageResult>(
            string path,
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
            where TPageResult : IResourcesPage<TResource>, new()
        {
            return SendAsync<TPageResult>(
                path,
                HttpMethod.GET,
                request?.GetParameters(),
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Executes a paginated search synchronously against the specified search endpoint
        /// and returns a page of matching resources.
        /// This is a blocking wrapper around <see cref="SearchAsync{TPageResult}"/>.
        /// </summary>
        /// <typeparam name="TPageResult">
        /// The page result type (e.g., <c>ResultsResourcesPage&lt;T&gt;</c>) that implements
        /// <see cref="IResourcesPage{TResource}"/>.
        /// </typeparam>
        /// <param name="path">Relative search endpoint path (e.g., <c>"/v1/customers/search"</c>).</param>
        /// <param name="request">
        /// A <see cref="SearchRequest"/> (or <see cref="AdvancedSearchRequest"/>) containing
        /// pagination, filter, sorting, and date-range parameters.
        /// </param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <typeparamref name="TPageResult"/> containing the matched resources and paging metadata.</returns>
        protected TPageResult Search<TPageResult>(
            string path,
            SearchRequest request,
            RequestOptions requestOptions = null)
            where TPageResult : IResourcesPage<TResource>, new()
        {
            return SearchAsync<TPageResult>(
                path,
                request,
                requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task<TResponse> SendAsync<TResponse>(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
            where TResponse : IResource, new()
        {
            MercadoPagoResponse response;
            requestOptions = BuildRequestOptions(requestOptions);

            try
            {
                MercadoPagoRequest mercadoPagoRequest = await BuildRequestAsync(
                    path,
                    httpMethod,
                    request,
                    requestOptions);

                response = await HttpClient.SendAsync(
                    mercadoPagoRequest,
                    requestOptions.RetryStrategy,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new MercadoPagoException(ex);
            }

            return ParseResponse<TResponse>(response);
        }

        private RequestOptions BuildRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            requestOptions.AccessToken = string.IsNullOrWhiteSpace(requestOptions.AccessToken) ?
                MercadoPagoConfig.AccessToken : requestOptions.AccessToken;
            requestOptions.RetryStrategy = requestOptions.RetryStrategy ?? MercadoPagoConfig.RetryStrategy;

            return requestOptions;
        }

        private MercadoPagoRequest BuildRequest(
            string path,
            HttpMethod httpMethod,
            RequestOptions requestOptions)
        {
            var mercadoPagoRequest = new MercadoPagoRequest
            {
                Url = $"{MercadoPagoConfig.BaseUrl}{path}",
                Method = httpMethod,
            };

            AddRequestHeaders(path, mercadoPagoRequest, requestOptions);

            return mercadoPagoRequest;
        }

        private async Task<MercadoPagoRequest> BuildRequestAsync(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions)
        {
            var mercadoPagoRequest = BuildRequest(path, httpMethod, requestOptions);
            var queryString = string.Empty;
            
            AddIdempotencyKey(mercadoPagoRequest, request);

            if (request != null)
            {
                if (httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT)
                {
                    mercadoPagoRequest.Content = Serializer.SerializeToJson(request);
                }
                else if (httpMethod == HttpMethod.GET)
                {
                    string parameters = await Serializer.SerializeToQueryStringAsync(request);
                    if (!string.IsNullOrEmpty(parameters))
                    {
                        queryString = $"?{parameters}";
                    }
                }
            }

            mercadoPagoRequest.Url = $"{mercadoPagoRequest.Url}{queryString}";

            return mercadoPagoRequest;
        }

        private void AddRequestHeaders(
            string path,
            MercadoPagoRequest mercadoPagoRequest,
            RequestOptions requestOptions)
        {
            foreach (var header in DefaultHeaders)
            {
                mercadoPagoRequest.Headers.Add(header);
            }

            path = path ?? string.Empty;
            if (!path.Equals("/oauth/token", StringComparison.InvariantCultureIgnoreCase))
            {
                mercadoPagoRequest.Headers.Add(Headers.AUTHORIZATION, $"Bearer {requestOptions.AccessToken}");
            }

            if (!string.IsNullOrWhiteSpace(MercadoPagoConfig.CorporationId))
            {
                mercadoPagoRequest.Headers.Add(Headers.CORPORATION_ID, MercadoPagoConfig.CorporationId);
            }

            if (!string.IsNullOrWhiteSpace(MercadoPagoConfig.IntegratorId))
            {
                mercadoPagoRequest.Headers.Add(Headers.INTEGRATOR_ID, MercadoPagoConfig.IntegratorId);
            }

            if (!string.IsNullOrWhiteSpace(MercadoPagoConfig.PlatformId))
            {
                mercadoPagoRequest.Headers.Add(Headers.PLATFORM_ID, MercadoPagoConfig.PlatformId);
            }

            foreach (var header in requestOptions.CustomHeaders)
            {
                if (!mercadoPagoRequest.Headers.ContainsKey(header.Key)
                    && !Headers.CONTENT_TYPE.Equals(header.Key, StringComparison.InvariantCultureIgnoreCase))
                {
                    mercadoPagoRequest.Headers.Add(header);
                }
            }
        }

        private void AddIdempotencyKey(MercadoPagoRequest mercadoPagoRequest, object request)
        {
            if (mercadoPagoRequest.Method == HttpMethod.POST || mercadoPagoRequest.Method == HttpMethod.PUT)
            {
                bool headerHasIdempotencyKey = mercadoPagoRequest.ContainsHeader(Headers.IDEMPOTENCY_KEY);
                if (request is IdempotentRequest idempotentRequest && !headerHasIdempotencyKey)
                {
                    mercadoPagoRequest.Headers.Add(Headers.IDEMPOTENCY_KEY, idempotentRequest.CreateIdempotencyKey());
                }

                if (request == null && !headerHasIdempotencyKey) {
                    mercadoPagoRequest.Headers.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());
                }
            }
        }

        private TResponse ParseResponse<TResponse>(MercadoPagoResponse response)
            where TResponse : IResource, new()
        {
            if (response.StatusCode > 299)
            {
                throw BuildApiErrorException(response);
            }

            TResponse resource;
            try
            {
                resource = Serializer.DeserializeFromJson<TResponse>(response.Content);
            }
            catch (Exception)
            {
                throw BuildInvalidResponseException(response);
            }

            if (!string.IsNullOrEmpty(response.Content)) {
                resource.ApiResponse = response;
            }

            return resource;
        }

        private MercadoPagoApiException BuildApiErrorException(MercadoPagoResponse response)
        {
            ApiError apiError;

            try
            {
                apiError = Serializer.DeserializeFromJson<ApiError>(response.Content);
            }
            catch (Exception)
            {
                apiError = null;
            }

            return new MercadoPagoApiException("Error response from API.", response)
            {
                ApiError = apiError,
            };
        }

        private MercadoPagoApiException BuildInvalidResponseException(MercadoPagoResponse response)
        {
            return new MercadoPagoApiException("Invalid response from API.", response);
        }
    }
}
