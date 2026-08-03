namespace MercadoPago.Error
{
    using System;

    /// <summary>
    /// Thrown on transport-level or network errors (timeout, DNS failure, SSL error).
    /// Wraps the underlying <see cref="Exception"/> from the HTTP client.
    /// </summary>
    public class MPConnectionException : MercadoPagoException
    {
        /// <inheritdoc />
        public MPConnectionException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
