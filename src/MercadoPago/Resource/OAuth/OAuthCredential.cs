namespace MercadoPago.Resource.OAuth
{
    using MercadoPago.Http;

    /// <summary>
    /// OAuth Credential.
    /// </summary>
    public class OAuthCredential : IResource
    {
        /// <summary>
        /// Marketplace seller token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The token type.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Expiration time in seconds.
        /// </summary>
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// Credential scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Token to refresh the credentials.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Identification number (Mercado Pago ID).
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Public key of the application.
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Production or test mode.
        /// </summary>
        public bool LiveMode { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
