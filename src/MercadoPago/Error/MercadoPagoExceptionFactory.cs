namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>
    /// Factory that maps an HTTP status code to the most specific
    /// <see cref="MercadoPagoApiException"/> subclass.
    /// </summary>
    /// <remarks>
    /// CWE-209: Authorization header values are never stored in exception objects;
    /// exceptions receive only the <see cref="MercadoPagoResponse"/> which contains
    /// the API response body, not the outgoing request headers.
    /// </remarks>
    public static class MercadoPagoExceptionFactory
    {
        private const string ErrorMessage = "Error response from API.";

        /// <summary>
        /// Creates the most specific exception subtype for the given response.
        /// </summary>
        public static MercadoPagoApiException Build(MercadoPagoResponse response)
        {
            var status = response?.StatusCode ?? 0;

            switch (status)
            {
                case 400: return new MPBadRequestException(ErrorMessage, response);
                case 401: return new MPAuthenticationException(ErrorMessage, response);
                case 402: return new MPPaymentException(ErrorMessage, response);
                case 403: return new MPForbiddenException(ErrorMessage, response);
                case 404: return new MPNotFoundException(ErrorMessage, response);
                case 409: return new MPIdempotencyException(ErrorMessage, response);
                case 422: return new MPValidationException(ErrorMessage, response);
                case 423: return new MPResourceLockedException(ErrorMessage, response);
                case 424: return new MPDependencyException(ErrorMessage, response);
                case 429:
                    var retryAfter = ParseRetryAfter(response);
                    return new MPRateLimitException(ErrorMessage, response, retryAfter);
                default:
                    if (status >= 500) return new MPServerException(ErrorMessage, response);
                    return new MercadoPagoApiException(ErrorMessage, response);
            }
        }

        private static int? ParseRetryAfter(MercadoPagoResponse response)
        {
            if (response?.Headers == null) return null;

            if (response.Headers.TryGetValue("Retry-After", out var value)
                && int.TryParse(value, out var seconds))
            {
                return seconds;
            }
            return null;
        }
    }
}
