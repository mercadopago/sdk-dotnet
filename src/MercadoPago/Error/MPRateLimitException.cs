namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>
    /// Thrown when the API returns HTTP 429 Too Many Requests.
    /// Exposes <see cref="RetryAfter"/> (seconds) from the <c>Retry-After</c> response header.
    /// </summary>
    public class MPRateLimitException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPRateLimitException(string message, MercadoPagoResponse response, int? retryAfter = null)
            : base(message, response)
        {
            RetryAfter = retryAfter;
        }

        /// <summary>
        /// Gets the number of seconds to wait before retrying, parsed from the
        /// <c>Retry-After</c> response header, or <c>null</c> if the header was absent.
        /// </summary>
        public int? RetryAfter { get; }
    }
}
