namespace MercadoPago.Tests.Client
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Resource;

    /// <summary>
    /// A dummy client just for tests
    /// </summary>
    public class DummyClient : MercadoPagoClient<DummyResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="serializer">The serializer.</param>
        public DummyClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Send a async request to api <paramref name="path"/> with HTTP method <paramref name="httpMethod"/>.
        /// The content body is in <paramref name="request"/>.
        /// </summary>
        /// <param name="path">Path of the endpoint.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A resource that represents the API response.</returns>
        public new Task<DummyResource> SendAsync(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return base.SendAsync(path, httpMethod, request, requestOptions, cancellationToken);
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
        public new DummyResource Send(
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
        public new Task<ResourcesList<DummyResource>> ListAsync(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return base.ListAsync(path, httpMethod, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// List the resources from <paramref name="path"/>.
        /// </summary>
        /// <param name="path">Path of API.</param>
        /// <param name="httpMethod">HTTP method.</param>
        /// <param name="request">Object with request data.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task whose result is a list of resources.
        /// </returns>
        public new ResourcesList<DummyResource> List(
            string path,
            HttpMethod httpMethod,
            object request,
            RequestOptions requestOptions = null)
        {
            return base.List(path, httpMethod, request, requestOptions);
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
        public Task<ResultsResourcesPage<DummyResource>> SearchAsync(
            string path,
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<DummyResource>>(
                path,
                request,
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
        public ResultsResourcesPage<DummyResource> Search(
            string path,
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<DummyResource>>(
                path,
                request,
                requestOptions);
        }
    }
}
