namespace MercadoPago.Client.OAuth
{
    /// <summary>
    /// Request DTO for refreshing an expired OAuth access token using a refresh token
    /// via the <c>/oauth/token</c> endpoint. Used internally by
    /// <see cref="OAuthClient.RefreshOAuthCredentialAsync"/>.
    /// </summary>
    public class RefreshOAuthCredentialRequest
    {
        /// <summary>
        /// The current access token used as the client secret for authenticating the refresh request.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// OAuth grant type. Always <c>"refresh_token"</c> for this request.
        /// </summary>
        public string GrantType => "refresh_token";

        /// <summary>
        /// Refresh token obtained from a previous <see cref="OAuthClient.CreateOAuthCredentialAsync(string, string, RequestOptions, System.Threading.CancellationToken)"/>
        /// call, used to obtain a new access token without requiring re-authorization.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
