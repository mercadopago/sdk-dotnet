namespace MercadoPago.Error
{
    using System;

    /// <summary>
    /// General-purpose exception for non-API errors that occur within the MercadoPago SDK,
    /// such as configuration problems, serialization failures, or unexpected internal errors.
    /// </summary>
    /// <remarks>
    /// For errors originating from MercadoPago API responses, see
    /// <see cref="MercadoPagoApiException"/> instead, which carries the HTTP status code
    /// and structured <see cref="ApiError"/> details.
    /// </remarks>
    public class MercadoPagoException : Exception
    {
        private const string DEFAULT_MESSAGE = "An unexpected error has occurred.";

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class
        /// with a custom message and the underlying exception that caused the error.
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        /// <param name="ex">The inner exception that caused this error.</param>
        public MercadoPagoException(string message, Exception ex)
            : base(message, ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class
        /// with a default message and the underlying exception that caused the error.
        /// </summary>
        /// <param name="ex">The inner exception that caused this error.</param>
        public MercadoPagoException(Exception ex)
            : base(DEFAULT_MESSAGE, ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class
        /// with a custom message and no inner exception.
        /// </summary>
        /// <param name="message">A human-readable description of the error.</param>
        public MercadoPagoException(string message)
            : base(message)
        {
        }
    }
}
