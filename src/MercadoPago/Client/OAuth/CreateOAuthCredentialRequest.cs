namespace MercadoPago.Client.OAuth
{
    /// <summary>
    /// Data to create an OAuth credential.
    /// </summary>
    public class CreateOAuthCredentialRequest
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Grant type (<c>authorization_code</c>).
        /// </summary>
        public string GrantType => "authorization_code";

        /// <summary>
        /// Authorization code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Redirect Uri.
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
