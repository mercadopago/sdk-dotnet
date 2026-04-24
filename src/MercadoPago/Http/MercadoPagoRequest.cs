namespace MercadoPago.Http
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulates all data needed to build and send an HTTP request to a MercadoPago API endpoint.
    /// </summary>
    /// <remarks>
    /// Instances are constructed by the SDK's resource layer and passed to
    /// <see cref="IHttpClient.SendAsync"/>. The <see cref="Headers"/> dictionary is initialized
    /// to an empty collection by default so callers can safely add headers without null checks.
    /// </remarks>
    public class MercadoPagoRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoRequest"/> class with all
        /// request properties.
        /// </summary>
        /// <param name="url">The fully-qualified URL of the API endpoint (e.g., <c>https://api.mercadopago.com/v1/payments</c>).</param>
        /// <param name="method">The <see cref="HttpMethod"/> to use for the request.</param>
        /// <param name="headers">
        /// A dictionary of HTTP headers to include. If <c>null</c>, an empty dictionary is used.
        /// </param>
        /// <param name="content">The JSON-serialized request body, or <c>null</c> for methods without a body.</param>
        public MercadoPagoRequest(
            string url,
            HttpMethod method,
            IDictionary<string, string> headers,
            string content)
        {
            Url = url;
            Method = method;
            Headers = headers ?? new Dictionary<string, string>();
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoRequest"/> class with default
        /// values: <see cref="HttpMethod.GET"/> method and an empty header collection.
        /// </summary>
        public MercadoPagoRequest()
        {
            Method = HttpMethod.GET;
            Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the fully-qualified URL of the API endpoint to call.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method for this request. Defaults to <see cref="HttpMethod.GET"/>.
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets the mutable dictionary of HTTP headers that will be sent with this request.
        /// </summary>
        /// <remarks>
        /// Always initialized to a non-null, empty dictionary. The SDK populates standard
        /// headers (authorization, tracking, idempotency) automatically before sending.
        /// </remarks>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets the JSON-serialized request body, or <c>null</c> when no body is needed.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Determines whether the <see cref="Headers"/> dictionary contains the specified header
        /// name, using a case-insensitive comparison.
        /// </summary>
        /// <param name="header">The header name to search for (case-insensitive).</param>
        /// <returns><c>true</c> if a header with the given name exists; otherwise, <c>false</c>.</returns>
        public bool ContainsHeader(string header)
        {
            foreach (string h in Headers.Keys)
            {
                if (h.Equals(header, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
