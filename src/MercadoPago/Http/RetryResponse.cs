namespace MercadoPago.Http
{
    using System;

    /// <summary>
    /// Represents the decision returned by <see cref="IRetryStrategy.ShouldRetry"/>, indicating
    /// whether to retry a failed HTTP request and how long to wait before the next attempt.
    /// </summary>
    public class RetryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryResponse"/> class with the
        /// specified retry decision and delay.
        /// </summary>
        /// <param name="retry"><c>true</c> to retry the request; <c>false</c> to stop retrying.</param>
        /// <param name="delay">
        /// The amount of time to wait before the next attempt. Ignored when <paramref name="retry"/>
        /// is <c>false</c>.
        /// </param>
        public RetryResponse(
            bool retry,
            TimeSpan delay)
        {
            Retry = retry;
            Delay = delay;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryResponse"/> class with default
        /// values (<see cref="Retry"/> = <c>false</c>, <see cref="Delay"/> = <see cref="TimeSpan.Zero"/>).
        /// </summary>
        public RetryResponse() { }

        /// <summary>
        /// Gets or sets a value indicating whether the HTTP request should be retried.
        /// </summary>
        public bool Retry { get; set; }

        /// <summary>
        /// Gets or sets the duration to wait before making the next retry attempt.
        /// </summary>
        public TimeSpan Delay { get; set; }
    }
}
