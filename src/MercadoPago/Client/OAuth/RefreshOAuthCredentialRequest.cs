namespace MercadoPago.Client.OAuth
{
    /// <summary>
    /// Data to refresh an OAuth credential.
    /// </summary>
    public class RefreshOAuthCredentialRequest
    {
        /// <summary>
        /// Client secret (Access Token).
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Grant type (<c>refresh_token</c>).
        /// </summary>
        public string GrantType => "refresh_token";

        /// <summary>
        /// Refresh token.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
