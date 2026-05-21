namespace MercadoPago.Resource.OAuth
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents OAuth 2.0 credentials returned by the MercadoPago
    /// authorization server. Used in marketplace integrations to obtain and
    /// refresh access tokens on behalf of connected sellers. Use
    /// <see cref="Client.OAuth.OAuthClient"/> to create and refresh
    /// credentials.
    /// </summary>
    public class OAuthCredential : IResource
    {
        /// <summary>
        /// Access token used to authenticate API requests on behalf of the
        /// authorized seller (marketplace scenario) or the application itself.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type. Typically <c>bearer</c>.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Number of seconds until the <see cref="AccessToken"/> expires.
        /// </summary>
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// OAuth scopes granted to this credential (e.g. <c>read</c>,
        /// <c>write</c>, <c>offline_access</c>).
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Refresh token used to obtain a new <see cref="AccessToken"/> after
        /// the current one expires.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// MercadoPago user identifier of the account that granted
        /// authorization.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Public key of the application, used for client-side token
        /// generation (e.g. with MercadoPago.js).
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// Indicates whether these credentials operate in production mode
        /// (<c>true</c>) or sandbox mode (<c>false</c>).
        /// </summary>
        public bool LiveMode { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
