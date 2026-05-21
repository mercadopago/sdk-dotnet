namespace MercadoPago.Http
{
    using System.Net.Http;

    /// <summary>
    /// Defines the contract for retry strategies that control whether and when failed HTTP
    /// requests to MercadoPago APIs should be retried.
    /// </summary>
    /// <remarks>
    /// Implement this interface to provide custom retry logic (e.g., different back-off algorithms,
    /// circuit-breaker patterns, or status-code-specific policies). The default implementation is
    /// <see cref="DefaultRetryStrategy"/>. Assign your implementation to
    /// <see cref="Config.MercadoPagoConfig.RetryStrategy"/> before making API calls.
    /// </remarks>
    public interface IRetryStrategy
    {
        /// <summary>
        /// Evaluates whether the failed HTTP request should be retried and, if so, how long to
        /// wait before the next attempt.
        /// </summary>
        /// <param name="httpRequest">The HTTP request that was sent.</param>
        /// <param name="httpResponse">
        /// The HTTP response received, or <c>null</c> if the request failed before receiving a response.
        /// </param>
        /// <param name="hadRetryableError">
        /// <c>true</c> if the failure was a transient transport-level error eligible for retry.
        /// </param>
        /// <param name="numberRetries">The number of retry attempts already executed (zero-based).</param>
        /// <returns>
        /// A <see cref="RetryResponse"/> indicating whether to retry and the delay before the next attempt.
        /// </returns>
        RetryResponse ShouldRetry(
            HttpRequestMessage httpRequest,
            HttpResponseMessage httpResponse,
            bool hadRetryableError,
            int numberRetries);
    }
}
