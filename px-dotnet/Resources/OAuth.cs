using System;
using System.Text;

namespace MercadoPago.Resources
{
    /// <summary>
    /// This class allows to get and refresh a OAuth token
    /// </summary>
    public class OAuth : MPBase
    {
        /// <summary>
        /// Client secret (access token)
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Grant type
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// Authorization code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Redirect Uri
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Public key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Live mode
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Token type
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Time to token expires (in minutes)
        /// </summary>
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// Token scope
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Get URL to generate authorization code
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="redirectUri">Redirect URL configured</param>
        /// <returns>URL to obtain the authorization code</returns>
        public static string GetAuthorizationURL(string appId, string redirectUri)
        {
            User user = User.Find();
            if (user == null || String.IsNullOrEmpty(user.CountryId))
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
        /// Get OAuth token credentials
        /// </summary>
        /// <param name="authorizationCode">Authorization code</param>
        /// <param name="redirectUri">Redirect Uri</param>
        /// <returns>OAuth token</returns>
        public static OAuth GetOAuthCredentials(string authorizationCode, string redirectUri)
        {
            var oAuth = new OAuth
            {
                ClientSecret = SDK.AccessToken,
                GrantType = "authorization_code",
                Code = authorizationCode,
                RedirectUri = redirectUri
            };
            oAuth.Save();
            return oAuth;
        }

        /// <summary>
        /// Refresh OAuth token
        /// </summary>
        /// <param name="refreshToken">Refresh token</param>
        /// <returns>Refreshed OAuth token</returns>
        public static OAuth RefreshOAuthCredentials(string refreshToken)
        {
            var oAuth = new OAuth
            {
                ClientSecret = SDK.AccessToken,
                GrantType = "refresh_token",
                RefreshToken = refreshToken
            };
            oAuth.Save();
            return oAuth;
        }

        /// <summary>
        /// Save OAuth token data
        /// </summary>
        /// <returns><see langword="true"/> if the token was saved, <see langword="false"/> otherwise</returns>
        [POSTEndpoint("/oauth/token")]
        public bool Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save OAuth token data
        /// </summary>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if the token was saved, <see langword="false"/> otherwise</returns>
        [POSTEndpoint("/oauth/token")]
        public bool Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<OAuth>("Save", WITHOUT_CACHE, requestOptions);
        }
    }
}
