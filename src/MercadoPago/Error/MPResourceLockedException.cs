namespace MercadoPago.Error
{
    using MercadoPago.Http;

    /// <summary>Auto-generated typed exception subclass of MercadoPagoApiException.</summary>
    public class MPResourceLockedException : MercadoPagoApiException
    {
        /// <inheritdoc />
        public MPResourceLockedException(string message, MercadoPagoResponse response)
            : base(message, response) { }
    }
}
