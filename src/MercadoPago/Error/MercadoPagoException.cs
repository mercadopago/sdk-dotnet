namespace MercadoPago.Error
{
    using System;

    /// <summary>
    /// Exception thrown when an unexpected error occurs.
    /// </summary>
    public class MercadoPagoException : Exception
    {
        private const string DEFAULT_MESSAGE = "An unexpected error has occurred.";

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="ex">The exception that caused the error.</param>
        public MercadoPagoException(string message, Exception ex)
            : base(message, ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class.
        /// </summary>
        /// <param name="ex">The exception that caused the error.</param>
        public MercadoPagoException(Exception ex)
            : base(DEFAULT_MESSAGE, ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public MercadoPagoException(string message)
            : base(message)
        {
        }
    }
}
