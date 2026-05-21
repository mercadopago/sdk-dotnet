namespace MercadoPago.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Default <see cref="IRetryStrategy"/> implementation that retries failed HTTP requests using
    /// exponential back-off with configurable minimum and maximum delays.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A request is eligible for retry only when all of the following are true:
    /// (1) the HTTP method is not POST, or a POST carries an <c>X-Idempotency-Key</c> header;
    /// (2) the number of retries already made is less than <see cref="MaxNumberRetries"/>;
    /// (3) the failure is a retryable transport error, or the response status code is 409 (Conflict)
    /// or &gt;= 500 (server error).
    /// </para>
    /// <para>
    /// Back-off delay is calculated as <c>MinDelay * 2^retryNumber</c>, capped at <see cref="MaxDelay"/>.
    /// </para>
    /// </remarks>
    public class DefaultRetryStrategy : IRetryStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRetryStrategy"/> class.
        /// </summary>
        /// <param name="maxNumberRetries">
        /// The maximum number of retry attempts before giving up. Must be zero or greater.
        /// </param>
        public DefaultRetryStrategy(int maxNumberRetries)
        {
            MaxNumberRetries = maxNumberRetries;
        }

        /// <summary>
        /// Gets the minimum delay between retry attempts. Value is 500 milliseconds.
        /// </summary>
        /// <remarks>
        /// This is the base delay for the first retry. Subsequent retries double this value
        /// (exponential back-off) up to <see cref="MaxDelay"/>.
        /// </remarks>
        public static TimeSpan MinDelay => TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Gets the maximum delay between retry attempts, acting as a ceiling for exponential back-off. Value is 5 seconds.
        /// </summary>
        public static TimeSpan MaxDelay => TimeSpan.FromSeconds(5);

        /// <summary>
        /// Gets the maximum number of automatic retry attempts before the request is considered failed.
        /// </summary>
        public int MaxNumberRetries { get; }

        /// <summary>
        /// Determines whether the HTTP request should be retried based on the request method,
        /// response status code, error type, and number of attempts already made.
        /// </summary>
        /// <param name="httpRequest">The HTTP request that was sent. Must not be a non-idempotent POST to be retryable.</param>
        /// <param name="httpResponse">The HTTP response received, or <c>null</c> if the request failed before a response was received.</param>
        /// <param name="hadRetryableError">
        /// <c>true</c> if the request encountered a transient transport error
        /// (e.g., <see cref="HttpRequestException"/> or a timeout not triggered by the caller).
        /// </param>
        /// <param name="numberRetries">The number of retry attempts that have already been executed (zero-based).</param>
        /// <returns>
        /// A <see cref="RetryResponse"/> indicating whether to retry and, if so, the delay to
        /// wait before the next attempt (computed via exponential back-off).
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
