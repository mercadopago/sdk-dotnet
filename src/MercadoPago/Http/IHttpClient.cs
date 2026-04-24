namespace MercadoPago.Http
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Abstraction for the HTTP transport layer used by the MercadoPago SDK to communicate with APIs.
    /// </summary>
    /// <remarks>
    /// Implement this interface to provide a custom HTTP transport (e.g., for mocking in tests
    /// or wrapping a different HTTP library). The default implementation is
    /// <see cref="DefaultHttpClient"/>. Assign your implementation to
    /// <see cref="Config.MercadoPagoConfig.HttpClient"/> before making any API calls.
    /// </remarks>
    public interface IHttpClient
    {
        /// <summary>
        /// Sends an HTTP request to MercadoPago APIs asynchronously, applying the specified retry strategy.
        /// </summary>
        /// <param name="request">
        /// The <see cref="MercadoPagoRequest"/> containing the URL, HTTP method, headers, and optional JSON body.
        /// </param>
        /// <param name="retryStrategy">
        /// The <see cref="IRetryStrategy"/> that decides whether and when to retry failed attempts.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that the caller can use to cancel the request.
        /// </param>
        /// <returns>
        /// A <see cref="Task{MercadoPagoResponse}"/> containing the status code, headers, and body of the API response.
        /// </returns>
        Task<MercadoPagoResponse> SendAsync(
            MercadoPagoRequest request,
            IRetryStrategy retryStrategy,
            CancellationToken cancellationToken);
    }
}
