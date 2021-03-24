namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Card number settings.
    /// </summary>
    public class PaymentMethodSettingsCardNumber
    {
        /// <summary>
        /// Card number length.
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Whether the card number can be validated using a checksum
        /// algorithm (usually Luhn).
        /// </summary>
        public string Validation { get; set; }
    }
}
