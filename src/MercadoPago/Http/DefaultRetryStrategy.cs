namespace MercadoPago.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Default retry strategy for HTTP request to MercadoPago's API
    /// </summary>
    public class DefaultRetryStrategy : IRetryStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRetryStrategy"/> class.
        /// </summary>
        /// <param name="maxNumberRetries">Max number of retries.</param>
        public DefaultRetryStrategy(int maxNumberRetries)
        {
            MaxNumberRetries = maxNumberRetries;
        }

        /// <summary>
        /// Minimum delay before retrying sending HTTP requests after a failure.
        /// </summary>
        public static TimeSpan MinDelay => TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Maximum delay before retrying sending HTTP requests after a failure.
        /// </summary>
        public static TimeSpan MaxDelay => TimeSpan.FromSeconds(5);

        /// <summary>
        /// Max number of retries.
        /// </summary>
        public int MaxNumberRetries { get; }

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
        public RetryResponse ShouldRetry(
            HttpRequestMessage httpRequest,
            HttpResponseMessage httpResponse,
            bool hadRetryableError,
            int numberRetries)
        {
            bool retry = IsRequestRetryable(httpRequest)
                && numberRetries < MaxNumberRetries
                && (hadRetryableError || IsResponseRetriable(httpResponse));

            TimeSpan delay = TimeSpan.Zero;
            if (retry)
            {
                delay = ExponentialBackoffDelay(numberRetries);
            }

            return new RetryResponse(retry, delay);
        }

        private static bool IsRequestRetryable(HttpRequestMessage httpRequest)
        {
            if (httpRequest == null)
            {
                return false;
            }

            return httpRequest.Method != System.Net.Http.HttpMethod.Post
                || (httpRequest.Headers.TryGetValues(Headers.IDEMPOTENCY_KEY, out IEnumerable<string> values)
                    && !string.IsNullOrWhiteSpace(string.Join("", values)));
        }

        private static bool IsResponseRetriable(HttpResponseMessage httpResponse)
        {
            if (httpResponse == null)
            {
                return false;
            }

            return httpResponse.StatusCode == HttpStatusCode.Conflict
                || (int)httpResponse.StatusCode >= (int)HttpStatusCode.InternalServerError;
        }

        private static TimeSpan ExponentialBackoffDelay(int numberRetries)
        {
            var delay = TimeSpan.FromTicks(
                (long)(MinDelay.Ticks * Math.Pow(2, numberRetries)));

            if (delay > MaxDelay)
            {
                delay = MaxDelay;
            }

            return delay;
        }
    }
}
