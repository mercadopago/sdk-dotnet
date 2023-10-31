namespace MercadoPago.Http
{
    /// <summary>
    /// Class with HTTP headers names
    /// </summary>
    public static class Headers
    {
        /// <summary>
        /// Authorization header name.
        /// </summary>
        public const string AUTHORIZATION = "Authorization";

        /// <summary>
        /// Content Type header name.
        /// </summary>
        public const string CONTENT_TYPE = "Content-Type";

        /// <summary>
        /// Accept header name.
        /// </summary>
        public const string ACCEPT = "Accept";

        /// <summary>
        /// User Agent header name.
        /// </summary>
        public const string USER_AGENT = "User-Agent";

        /// <summary>
        /// Idempotency Key header name.
        /// </summary>
        public const string IDEMPOTENCY_KEY = "X-Idempotency-Key";

        /// <summary>
        /// Internal product ID header name.
        /// </summary>
        public const string PRODUCT_ID = "X-Product-Id";

        /// <summary>
        /// Corporation ID header name.
        /// </summary>
        public const string CORPORATION_ID = "X-Corporation-Id";

        /// <summary>
        /// Integrator ID header name.
        /// </summary>
        public const string INTEGRATOR_ID = "X-Integrator-Id";

        /// <summary>
        /// Platform ID header name.
        /// </summary>
        public const string PLATFORM_ID = "X-Platform-Id";

        /// <summary>
        /// Tracking ID header name.
        /// </summary>
        public const string TRACKING_ID = "X-Tracking-Id";
    }
}
