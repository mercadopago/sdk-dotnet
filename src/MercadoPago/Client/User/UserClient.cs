namespace MercadoPago.Client.User
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.User;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Users API (<c>/users/me</c>).
    /// Retrieves the profile of the user associated with the current access token,
    /// including country, site, and account details. Also used internally by
    /// <see cref="OAuth.OAuthClient"/> to determine the country-specific authorization URL.
    /// </summary>
    public class UserClient : MercadoPagoClient<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public UserClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public UserClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public UserClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        public UserClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Retrieves the profile of the authenticated user asynchronously.
        /// The user is identified by the access token configured in
        /// <see cref="Config.MercadoPagoConfig"/> or overridden via <paramref name="requestOptions"/>.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="User"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<User> GetAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/users/me",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves the profile of the authenticated user synchronously.
        /// The user is identified by the access token configured in
        /// <see cref="Config.MercadoPagoConfig"/> or overridden via <paramref name="requestOptions"/>.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="User"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public User Get(
            RequestOptions requestOptions = null)
        {
            return Send(
                "/users/me",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
