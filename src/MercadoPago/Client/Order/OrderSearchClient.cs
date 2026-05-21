namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Internal client that handles searching for orders via <c>GET /v1/orders</c>.
    /// This client exists because the search response type (<see cref="OrderSearchResponse"/>)
    /// differs from the single-order resource type, requiring a separate generic base class binding.
    /// Typically accessed indirectly through <see cref="OrderClient.Search(OrderSearchRequest, RequestOptions)"/>.
    /// </summary>
    /// <seealso cref="OrderClient"/>
    /// <seealso cref="OrderSearchRequest"/>
    internal class OrderSearchClient : MercadoPagoClient<OrderSearchResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSearchClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderSearchClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Searches for orders matching the given criteria as an asynchronous operation.
        /// </summary>
        /// <param name="request">The search filters, pagination, and sorting parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the paginated search response containing matching orders.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public Task<OrderSearchResponse> SearchAsync(
            OrderSearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/v1/orders", HttpMethod.GET, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Searches for orders matching the given criteria synchronously.
        /// </summary>
        /// <param name="request">The search filters, pagination, and sorting parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The paginated search response containing matching orders.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        public OrderSearchResponse Search(
            OrderSearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/v1/orders", HttpMethod.GET, request, requestOptions);
        }
    }
}
