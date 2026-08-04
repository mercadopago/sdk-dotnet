namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPIdempotencyException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPIdempotencyException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
