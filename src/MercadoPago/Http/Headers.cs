namespace MercadoPago.Http
{
    /// <summary>
    /// Defines the HTTP header names used by the MercadoPago SDK when building API requests.
    /// </summary>
    /// <remarks>
    /// These constants are referenced by the SDK's request-building infrastructure to attach
    /// authentication, tracking, and idempotency headers. Custom <see cref="IHttpClient"/>
    /// implementations should honor these same header names.
    /// </remarks>
    public static class Headers
    {
        /// <summary>
        /// The <c>Authorization</c> header, used to carry the Bearer access token.
        /// </summary>
        public const string AUTHORIZATION = "Authorization";

        /// <summary>
        /// The <c>Content-Type</c> header. The SDK always sends <c>application/json</c>.
        /// </summary>
        public const string CONTENT_TYPE = "Content-Type";

        /// <summary>
        /// The <c>Accept</c> header, indicating the media types the client can process.
        /// </summary>
        public const string ACCEPT = "Accept";

        /// <summary>
        /// The <c>User-Agent</c> header, identifying the SDK and runtime to the API.
        /// </summary>
        public const string USER_AGENT = "User-Agent";

        /// <summary>
        /// The <c>X-Idempotency-Key</c> header, ensuring that POST requests can be safely retried
        /// without creating duplicate resources on the server.
        /// </summary>
        public const string IDEMPOTENCY_KEY = "X-Idempotency-Key";

        /// <summary>
        /// The <c>X-Product-Id</c> header, carrying the SDK's internal product identifier for analytics.
        /// </summary>
        public const string PRODUCT_ID = "X-Product-Id";

        /// <summary>
        /// The <c>X-Corporation-Id</c> header, identifying the corporation in marketplace integrations.
        /// </summary>
        public const string CORPORATION_ID = "X-Corporation-Id";

        /// <summary>
        /// The <c>X-Integrator-Id</c> header, identifying the third-party integrator for commission tracking.
        /// </summary>
        public const string INTEGRATOR_ID = "X-Integrator-Id";

        /// <summary>
        /// The <c>X-Platform-Id</c> header, identifying the e-commerce platform hosting the integration.
        /// </summary>
        public const string PLATFORM_ID = "X-Platform-Id";

        /// <summary>
        /// The <c>X-Tracking-Id</c> header, carrying SDK version and runtime information for diagnostics.
        /// </summary>
        public const string TRACKING_ID = "X-Tracking-Id";
    }
}
