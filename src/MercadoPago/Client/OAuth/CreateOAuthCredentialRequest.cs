namespace MercadoPago.Client.OAuth
{
    /// <summary>
    /// Request DTO for exchanging an authorization code for OAuth access and refresh tokens
    /// via the <c>/oauth/token</c> endpoint. Used internally by
    /// <see cref="OAuthClient.CreateOAuthCredentialAsync(string, string, RequestOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class CreateOAuthCredentialRequest
    {
        /// <summary>
        /// Application (client) ID registered in the MercadoPago developer portal.
        /// Required when authenticating with explicit client credentials; when <c>null</c>,
        /// the configured access token is used as the client secret instead.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Application (client) secret or the current access token, depending on the
        /// authentication flow used.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// OAuth grant type. Always <c>"authorization_code"</c> for this request.
        /// </summary>
        public string GrantType => "authorization_code";

        /// <summary>
        /// Authorization code received from the MercadoPago authorization redirect
        /// after the user grants access.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Redirect URI registered for the application. Must match the URI used in the
        /// authorization request that produced <see cref="Code"/>.
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
