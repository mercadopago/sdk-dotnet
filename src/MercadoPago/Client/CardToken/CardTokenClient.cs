namespace MercadoPago.Client.CardToken
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Card Token API (<c>/v1/card_tokens</c>).
    /// Card tokens are single-use, short-lived representations of card data that allow
    /// payments to be created without transmitting raw card details.
    /// Use this client to create new card tokens or to retrieve existing ones by ID.
    /// </summary>
    public class CardTokenClient : MercadoPagoClient<CardToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardTokenClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CardTokenClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardTokenClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public CardTokenClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardTokenClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CardTokenClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardTokenClient"/> class.
        /// </summary>
        public CardTokenClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Retrieves card token data by its ID asynchronously.
        /// </summary>
        /// <param name="id">The card token identifier (the token string returned when the token was created).</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="CardToken"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<CardToken> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/card_tokens/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves card token data by its ID synchronously.
        /// </summary>
        /// <param name="id">The card token identifier (the token string returned when the token was created).</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="CardToken"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public CardToken Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/card_tokens/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Creates a new card token asynchronously from a saved card reference.
        /// The resulting token can then be used as the <c>token</c> field when creating a payment.
        /// </summary>
        /// <param name="request">A <see cref="CardTokenRequest"/> containing the card ID, customer ID, and security code.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="CardToken"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<CardToken> CreateAsync(
            CardTokenRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/v1/card_tokens",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a new card token synchronously from a saved card reference.
        /// The resulting token can then be used as the <c>token</c> field when creating a payment.
        /// </summary>
        /// <param name="request">A <see cref="CardTokenRequest"/> containing the card ID, customer ID, and security code.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="CardToken"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public CardToken Create(
            CardTokenRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                "/v1/card_tokens",
                HttpMethod.POST,
                request,
                requestOptions);
        }
    }
}
