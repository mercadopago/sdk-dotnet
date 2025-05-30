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
    /// Client that uses the Chargeback APIs.
    /// </summary>
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
        /// Get a Chargeback by your ID asynchronously.
        /// </summary>
        /// <param name="id">The Chargeback ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the Chargeback.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/_chargebacks_id/get">here</a>.
        /// </remarks>
        public Task<Chargeback> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/chargebacks/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Get a Chargeback by your ID.
        /// </summary>
        /// <param name="id">The Chargeback ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The Chargeback.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/_chargebacks_id/get">here</a>.
        /// </remarks>
        public Chargeback Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/chargebacks/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Searches async for Chargebacks that match the criteria of <see cref="SearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is a page of Chargebacks.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/_chargebacks_search/get">here</a>.
        /// </remarks>
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
        /// Searches for Chargebacks that match the criteria of <see cref="SearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A page of Chargebacks.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/_chargebacks_search/get">here</a>.
        /// </remarks>
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
