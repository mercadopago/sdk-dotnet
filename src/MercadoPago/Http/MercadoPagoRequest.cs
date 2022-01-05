namespace MercadoPago.Http
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains request data to MercadoPago's APIs.
    /// </summary>
    public class MercadoPagoRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoRequest"/> class.
        /// </summary>
        /// <param name="url">The url of the request.</param>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="headers">The headers of the request.</param>
        /// <param name="content">The content body of the request as string.</param>
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
        /// Initializes a new instance of the <see cref="MercadoPagoRequest"/> class.
        /// </summary>
        public MercadoPagoRequest()
        {
            Method = HttpMethod.GET;
            Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Request URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// <see cref="HttpMethod"/> value that represents the HTTP method.
        /// The deafult value is <see cref="HttpMethod.GET"/>.
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// HTTP headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Request body content as JSON string.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Receives a string and returns true if the string is a key of the headers
        /// </summary>
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
