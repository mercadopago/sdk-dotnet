namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPNotFoundException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPNotFoundException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
