namespace MercadoPago.Client.CardToken
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client to use Card Token API.
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
        /// Get async the card token data by your ID (token).
        /// </summary>
        /// <param name="id">The card token ID (token).</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the card token.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Get the card token data by your ID (token).
        /// </summary>
        /// <param name="id">The card token ID (token).</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The card token.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a card token as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create the card token.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the created card token.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a card token.
        /// </summary>
        /// <param name="request">The data to create the card token.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The created card token.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
