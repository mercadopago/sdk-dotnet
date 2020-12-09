namespace MercadoPago.Http
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for HTTP clients used to make requests to MercadoPago's API.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Sends a HTTP request to MercadoPago's APIs.
        /// </summary>
        /// <param name="request">Request data.</param>
        /// <param name="retryStrategy">Strategy to be used when it is necessary to retry the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation.</param>
        /// <returns>A Task with response data.</returns>
        Task<MercadoPagoResponse> SendAsync(
            MercadoPagoRequest request,
            IRetryStrategy retryStrategy,
            CancellationToken cancellationToken);
    }
}
