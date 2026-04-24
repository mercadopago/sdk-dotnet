namespace MercadoPago.Http
{
    /// <summary>
    /// Enumerates the HTTP methods supported by the MercadoPago SDK for API requests.
    /// </summary>
    /// <remarks>
    /// This SDK-specific enum is mapped to <see cref="System.Net.Http.HttpMethod"/> values
    /// internally by <see cref="DefaultHttpClient"/>. Only the methods required by the
    /// MercadoPago REST API are included.
    /// </remarks>
    public enum HttpMethod
    {
        /// <summary>
        /// HTTP GET method, used to retrieve resources.
        /// </summary>
        GET,
        /// <summary>
        /// HTTP POST method, used to create resources. POST requests require an idempotency key
        /// (see <see cref="Headers.IDEMPOTENCY_KEY"/>) to be safely retried.
        /// </summary>
        POST,
        /// <summary>
        /// HTTP PUT method, used to fully update existing resources.
        /// </summary>
        PUT,
        /// <summary>
        /// HTTP DELETE method, used to remove resources.
        /// </summary>
        DELETE,
    }
}
