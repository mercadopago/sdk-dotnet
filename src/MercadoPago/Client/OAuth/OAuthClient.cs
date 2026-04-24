namespace MercadoPago.Client.OAuth
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client.User;
    using MercadoPago.Config;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.OAuth;
    using MercadoPago.Resource.User;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago OAuth API (<c>/oauth/token</c>).
    /// Implements the OAuth 2.0 authorization-code flow: building authorization URLs,
    /// exchanging authorization codes for access/refresh tokens, and refreshing expired tokens.
    /// Uses an internal <see cref="UserClient"/> to resolve the user's country for the authorization URL.
    /// </summary>
    public class OAuthClient : MercadoPagoClient<OAuthCredential>
    {
        private readonly UserClient userClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OAuthClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            userClient = new UserClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public OAuthClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OAuthClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthClient"/> class.
        /// </summary>
        public OAuthClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Builds the MercadoPago authorization URL asynchronously.
        /// The URL is country-specific (e.g., <c>auth.mercadopago.com.br</c>) and is
        /// determined by fetching the current user's country via the Users API.
        /// </summary>
        /// <param name="appId">The application (client) ID registered in the MercadoPago developer portal.</param>
        /// <param name="redirectUri">The redirect URI registered for the application, where the authorization code will be sent.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task whose result is the full authorization URL to redirect the user to,
        /// or <c>null</c> if the user's country could not be determined.
        /// </returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public async Task<string> GetAuthorizationURLAsync(
            string appId,
            string redirectUri,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            User user = await userClient.GetAsync(requestOptions, cancellationToken);
            if (user == null || string.IsNullOrEmpty(user.CountryId))
            {
                return null;
            }

            return new StringBuilder()
                .Append("https://auth.mercadopago.com.")
                .Append(user.CountryId.ToLowerInvariant())
                .Append("/authorization?client_id=")
                .Append(appId)
                .Append("&response_type=code&platform_id=mp&redirect_uri=")
                .Append(redirectUri)
                .ToString();
        }

        /// <summary>
        /// Builds the MercadoPago authorization URL synchronously.
        /// The URL is country-specific (e.g., <c>auth.mercadopago.com.br</c>) and is
        /// determined by fetching the current user's country via the Users API.
        /// </summary>
        /// <param name="appId">The application (client) ID registered in the MercadoPago developer portal.</param>
        /// <param name="redirectUri">The redirect URI registered for the application, where the authorization code will be sent.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>
        /// The full authorization URL to redirect the user to,
        /// or <c>null</c> if the user's country could not be determined.
        /// </returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public string GetAuthorizationURL(
            string appId,
            string redirectUri,
            RequestOptions requestOptions = null)
        {
            User user = userClient.Get(requestOptions);
            if (user == null || string.IsNullOrEmpty(user.CountryId))
            {
                return null;
            }

            return new StringBuilder()
                .Append("https://auth.mercadopago.com.")
                .Append(user.CountryId.ToLowerInvariant())
                .Append("/authorization?client_id=")
                .Append(appId)
                .Append("&response_type=code&platform_id=mp&redirect_uri=")
                .Append(redirectUri)
                .ToString();
        }
        /// <summary>
        /// Exchanges an authorization code for OAuth credentials asynchronously,
        /// using the configured access token as the client secret.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the MercadoPago authorization redirect.</param>
        /// <param name="redirectUri">The redirect URI that was used in the original authorization request.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="OAuthCredential"/> containing the access and refresh tokens.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<OAuthCredential> CreateOAuthCredentialAsync(
            string authorizationCode,
            string redirectUri,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            string accessToken;
            if (requestOptions != null)
            {
                accessToken = string.IsNullOrWhiteSpace(requestOptions.AccessToken) ?
                    MercadoPagoConfig.AccessToken : requestOptions.AccessToken;
            }
            else
            {
                accessToken = MercadoPagoConfig.AccessToken;
            }

            var request = new CreateOAuthCredentialRequest
            {
                ClientSecret = accessToken,
                Code = authorizationCode,
                RedirectUri = redirectUri,
            };
            return SendAsync(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Exchanges an authorization code for OAuth credentials asynchronously,
        /// using explicit client ID and client secret values.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the MercadoPago authorization redirect.</param>
        /// <param name="clientId">The application (client) ID registered in the MercadoPago developer portal.</param>
        /// <param name="clientSecret">The application (client) secret from the MercadoPago developer portal.</param>
        /// <param name="redirectUri">The redirect URI that was used in the original authorization request.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="OAuthCredential"/> containing the access and refresh tokens.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<OAuthCredential> CreateOAuthCredentialAsync(
            string authorizationCode,
            string clientId,
            string clientSecret,
            string redirectUri,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var request = new CreateOAuthCredentialRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Code = authorizationCode,
                RedirectUri = redirectUri,
            };
            return SendAsync(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Exchanges an authorization code for OAuth credentials synchronously,
        /// using the configured access token as the client secret.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the MercadoPago authorization redirect.</param>
        /// <param name="redirectUri">The redirect URI that was used in the original authorization request.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="OAuthCredential"/> containing the access and refresh tokens.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public OAuthCredential CreateOAuthCredential(
            string authorizationCode,
            string redirectUri,
            RequestOptions requestOptions = null)
        {
            string accessToken;
            if (requestOptions != null)
            {
                accessToken = string.IsNullOrWhiteSpace(requestOptions.AccessToken) ?
                    MercadoPagoConfig.AccessToken : requestOptions.AccessToken;
            }
            else
            {
                accessToken = MercadoPagoConfig.AccessToken;
            }

            var request = new CreateOAuthCredentialRequest
            {
                ClientSecret = accessToken,
                Code = authorizationCode,
                RedirectUri = redirectUri,
            };
            return Send(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Exchanges an authorization code for OAuth credentials synchronously,
        /// using explicit client ID and client secret values.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the MercadoPago authorization redirect.</param>
        /// <param name="clientId">The application (client) ID registered in the MercadoPago developer portal.</param>
        /// <param name="clientSecret">The application (client) secret from the MercadoPago developer portal.</param>
        /// <param name="redirectUri">The redirect URI that was used in the original authorization request.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="OAuthCredential"/> containing the access and refresh tokens.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public OAuthCredential CreateOAuthCredential(
            string authorizationCode,
            string clientId,
            string clientSecret,
            string redirectUri,
            RequestOptions requestOptions = null)
        {
            var request = new CreateOAuthCredentialRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Code = authorizationCode,
                RedirectUri = redirectUri,
            };
            return Send(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Refreshes an expired OAuth access token asynchronously using a previously obtained refresh token.
        /// The configured access token is used as the client secret for authentication.
        /// </summary>
        /// <param name="refreshToken">The refresh token obtained from a previous credential creation call.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the refreshed <see cref="OAuthCredential"/> with a new access token.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<OAuthCredential> RefreshOAuthCredentialAsync(
            string refreshToken,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            string accessToken;
            if (requestOptions != null)
            {
                accessToken = string.IsNullOrWhiteSpace(requestOptions.AccessToken) ?
                    MercadoPagoConfig.AccessToken : requestOptions.AccessToken;
            }
            else
            {
                accessToken = MercadoPagoConfig.AccessToken;
            }

            var request = new RefreshOAuthCredentialRequest
            {
                ClientSecret = accessToken,
                RefreshToken = refreshToken,
            };
            return SendAsync(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Refreshes an expired OAuth access token synchronously using a previously obtained refresh token.
        /// The configured access token is used as the client secret for authentication.
        /// </summary>
        /// <param name="refreshToken">The refresh token obtained from a previous credential creation call.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The refreshed <see cref="OAuthCredential"/> with a new access token.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public OAuthCredential RefreshOAuthCredential(
            string refreshToken,
            RequestOptions requestOptions = null)
        {
            string accessToken;
            if (requestOptions != null)
            {
                accessToken = string.IsNullOrWhiteSpace(requestOptions.AccessToken) ?
                    MercadoPagoConfig.AccessToken : requestOptions.AccessToken;
            }
            else
            {
                accessToken = MercadoPagoConfig.AccessToken;
            }

            var request = new RefreshOAuthCredentialRequest
            {
                ClientSecret = accessToken,
                RefreshToken = refreshToken,
            };
            return Send(
                "/oauth/token",
                HttpMethod.POST,
                request,
                requestOptions);
        }
    }
}
