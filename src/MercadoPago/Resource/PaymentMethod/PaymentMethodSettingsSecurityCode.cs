namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Security code settings.
    /// </summary>
    public class PaymentMethodSettingsSecurityCode
    {
        /// <summary>
        /// Whether the security code is mandatory or not.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Secutiry code length.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Whether the security code is located in the back or in the front
        /// of the card.
        /// </summary>
        public string CardLocation { get; set; }
    }
}
