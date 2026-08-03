namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPForbiddenException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPForbiddenException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
