namespace MercadoPago.Http
{
    using System.Net.Http;

    /// <summary>
    /// Interface for retry strategy in HTTP requests
    /// </summary>
    public interface IRetryStrategy
    {
        /// <summary>
        /// Indicates if should retry the HTTP request.
        /// </summary>
        /// <param name="httpRequest">The HTTP request data sent.</param>
        /// <param name="httpResponse">The HTTP response data if the HTTP request succeeded.</param>
        /// <param name="hadRetryableError">If the HTTP request had a retryable error.</param>
        /// <param name="numberRetries">Number of retries already made.</param>
        /// <returns>
        /// A <see cref="RetryResponse"/> indicating if should retry
        /// and the time to delay before next retry.
        /// </returns>
        RetryResponse ShouldRetry(
            HttpRequestMessage httpRequest,
            HttpResponseMessage httpResponse,
            bool hadRetryableError,
            int numberRetries);
    }
}
