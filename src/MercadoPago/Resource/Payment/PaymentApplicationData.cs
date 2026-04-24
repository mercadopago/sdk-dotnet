namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Information about the application that initiated the payment interaction,
    /// as reported in the <see cref="PaymentPointOfInteraction"/>.
    /// </summary>
    public class PaymentApplicationData
    {
        /// <summary>
        /// Name of the application or system that initiated the payment
        /// (e.g., the POS terminal name or checkout application).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Version of the application or system that initiated the payment.
        /// </summary>
        public string Version { get; set; }
    }
}
