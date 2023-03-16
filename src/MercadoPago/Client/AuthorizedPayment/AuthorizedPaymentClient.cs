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
    /// Client that use the Authorized Payments (also known as Invoices) APIs.
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
        /// Gets an AuthorizedPayment by ID.
        /// </summary>
        /// <param name="id">The AuthorizedPayment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the AuthorizedPayment.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<AuthorizedPayment> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/authorized_payments/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets an AuthorizedPayment by ID.
        /// </summary>
        /// <param name="id">The AuthorizedPayment ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The AuthorizedPayment.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public AuthorizedPayment Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send($"/authorized_payments/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Searches async for AuthorizedPayment that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is a page of AuthorizedPayments.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Searches for AuthorizedPayment that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A page of AuthorizedPayment.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
