namespace MercadoPago.Http
{
    using System;

    /// <summary>
    /// Class that has retry information.
    /// </summary>
    public class RetryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetryResponse"/> class.
        /// </summary>
        /// <param name="retry">Should retry (<c>true</c>) or not (<c>false</c>).</param>
        /// <param name="delay">Time to delay in ms before the next attempt.</param>
        public RetryResponse(
            bool retry,
            TimeSpan delay)
        {
            Retry = retry;
            Delay = delay;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetryResponse"/> class.
        /// </summary>
        public RetryResponse() { }

        /// <summary>
        /// Should retry (<c>true</c>) or not (<c>false</c>).
        /// </summary>
        public bool Retry { get; set; }

        /// <summary>
        /// Time to delay in ms.
        /// </summary>
        public TimeSpan Delay { get; set; }
    }
}
