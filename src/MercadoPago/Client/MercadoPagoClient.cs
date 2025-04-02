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
    /// Base class for APIs clients.
    /// </summary>
    /// <typeparam name="TResource">Type of the resource.</typeparam>
    public abstract class MercadoPagoClient<TResource>
        where TResource : IResource, new()
    {
        private const string ACCEPT_VALUE = "application/json";

        /// <summary>
        /// Constructor of the <see cref="MercadoPagoClient{TResource}"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
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
        /// The defaults headers that will be sended in every request.
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
        /// Send a async request to api <paramref name="path"/> with HTTP method <paramref name="httpMethod"/>.
        /// The content body is in <paramref name="request"/>.
        /// </summary>
        /// <param name="path">Path of the endpoint.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task whose result is a resource that represents the API response.
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
        /// Send a request to api <paramref name="path"/> with HTTP method <paramref name="httpMethod"/>.
        /// The content body is in <paramref name="request"/>.
        /// </summary>
        /// <param name="path">Path of the endpoint.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>A resource that represents the API response.</returns>
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
        /// List async the resources from <paramref name="path"/>.
        /// </summary>
        /// <param name="path">Path of API.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task whose result is a list of resources.
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
        /// List the resources from <paramref name="path"/>.
        /// </summary>
        /// <param name="path">Path of API.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>
        /// A task whose result is a list of resources.
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
        /// Searches async and returns a result page with resources.
        /// </summary>
        /// <typeparam name="TPageResult">The type of page.</typeparam>
        /// <param name="path">Path of search API.</param>
        /// <param name="request">Object with search parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task whose result is a search response page.
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
        /// Searches and returns a result page with resources.
        /// </summary>
        /// <typeparam name="TPageResult">The type of page.</typeparam>
        /// <param name="path">Path of search API.</param>
        /// <param name="request">Object with search parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A search response page.</returns>
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
