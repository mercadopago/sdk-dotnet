namespace MercadoPago.Client.Chargeback
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Chargeback;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Chargebacks API (<c>/v1/chargebacks</c>).
    /// Provides read-only access to chargeback dispute records initiated by
    /// cardholders through their issuing bank.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/">here</a>.
    /// </remarks>
    public class ChargebackClient : MercadoPagoClient<Chargeback>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargebackClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public ChargebackClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargebackClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public ChargebackClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargebackClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public ChargebackClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargebackClient"/> class.
        /// </summary>
        public ChargebackClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a chargeback by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique numeric identifier of the chargeback to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="Chargeback"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<Chargeback> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/chargebacks/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a chargeback by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique numeric identifier of the chargeback to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="Chargeback"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Chargeback Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/chargebacks/{EncodePathParam(id)}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Searches for chargebacks matching the specified criteria asynchronously.
        /// </summary>
        /// <param name="request">Search parameters including filters and pagination.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of matching <see cref="Chargeback"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<ResultsResourcesPage<Chargeback>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<Chargeback>>(
                "/v1/chargebacks/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for chargebacks matching the specified criteria synchronously.
        /// </summary>
        /// <param name="request">Search parameters including filters and pagination.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A paginated list of matching <see cref="Chargeback"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public ResultsResourcesPage<Chargeback> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<Chargeback>>(
                "/v1/chargebacks/search",
                request,
                requestOptions);
        }
    }
}
