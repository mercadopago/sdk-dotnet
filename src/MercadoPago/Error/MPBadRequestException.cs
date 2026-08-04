namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPBadRequestException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPBadRequestException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
