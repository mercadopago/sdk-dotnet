namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPDependencyException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPDependencyException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
