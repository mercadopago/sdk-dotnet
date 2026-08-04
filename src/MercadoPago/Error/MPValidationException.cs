namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPValidationException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPValidationException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
