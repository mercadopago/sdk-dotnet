namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPServerException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPServerException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
