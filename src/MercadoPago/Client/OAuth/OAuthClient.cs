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
    /// Client with methods to create a OAuth Credential.
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
        /// Gets async the URL to generate authorization code.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="redirectUri">Redirect URL configured</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the URL to obtain the authorization code.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Gets the URL to generate authorization code.
        /// </summary>
        /// <param name="appId">Application ID.</param>
        /// <param name="redirectUri">Redirect URL configured.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A task whose the result is the URL to obtain the authorization code.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates an OAuth credentials asynchronously using
        /// access token as client secret.
        /// </summary>
        /// <param name="authorizationCode">Authorization code.</param>
        /// <param name="redirectUri">Redirect Uri.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates an OAuth credentials asynchronously with
        /// client id and client secret.
        /// </summary>
        /// <param name="authorizationCode">Authorization code.</param>
        /// <param name="clientId">Client Id.</param>
        /// <param name="clientSecret">Client Secret.</param>
        /// <param name="redirectUri">Redirect Uri.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates an OAuth credentials using
        /// access token as client secret.
        /// </summary>
        /// <param name="authorizationCode">Authorization code.</param>
        /// <param name="redirectUri">Redirect Uri.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates an OAuth credentials with
        /// client id and client secret.
        /// </summary>
        /// <param name="authorizationCode">Authorization code.</param>
        /// <param name="clientId">Client Id.</param>
        /// <param name="clientSecret">Client Secret.</param>
        /// <param name="redirectUri">Redirect Uri.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Refresh OAuth credential async.
        /// </summary>
        /// <param name="refreshToken">Refresh token.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the refreshed OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Refresh OAuth credential.
        /// </summary>
        /// <param name="refreshToken">Refresh token.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The refreshed OAuth credential.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
