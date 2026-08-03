namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPAuthenticationException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPAuthenticationException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
