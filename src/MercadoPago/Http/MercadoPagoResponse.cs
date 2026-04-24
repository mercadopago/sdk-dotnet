namespace MercadoPago.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the HTTP response received from a MercadoPago API call, including the status
    /// code, response headers, and the raw response body.
    /// </summary>
    /// <remarks>
    /// Instances are created by <see cref="IHttpClient"/> implementations after reading the
    /// full response stream. The <see cref="Content"/> is the raw JSON string that can be
    /// deserialized into resource objects or <see cref="Error.ApiError"/> instances.
    /// </remarks>
    public class MercadoPagoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoResponse"/> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code (e.g., 200, 400, 500).</param>
        /// <param name="headers">
        /// A dictionary of response headers. Multi-value headers are joined with commas.
        /// </param>
        /// <param name="content">The raw response body as a string, or <c>null</c> if the response had no body.</param>
        public MercadoPagoResponse(
            int statusCode,
            IDictionary<string, string> headers,
            string content)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
        }

        /// <summary>
        /// Gets the HTTP status code returned by the API (e.g., 200 for success, 400 for bad request).
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the dictionary of HTTP response headers returned by the API.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets the raw response body as a string, typically JSON. May be <c>null</c> if the response contained no body.
        /// </summary>
        public string Content { get; }
    }
}
