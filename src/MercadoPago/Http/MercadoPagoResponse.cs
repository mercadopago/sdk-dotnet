namespace MercadoPago.Http
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains response data from MercadoPago's APIs.
    /// </summary>
    public class MercadoPagoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoResponse"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP response status code.</param>
        /// <param name="headers">HTTP response headers.</param>
        /// <param name="content">HTTP response content as string.</param>
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
        /// HTTP status code.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// HTTP response headers.
        /// </summary>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Response content as string.
        /// </summary>
        public string Content { get; }
    }
}
