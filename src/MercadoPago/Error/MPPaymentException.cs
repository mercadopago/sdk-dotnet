namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPPaymentException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPPaymentException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
