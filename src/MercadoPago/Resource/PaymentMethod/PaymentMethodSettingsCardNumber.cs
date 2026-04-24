namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Card number constraints within a <see cref="PaymentMethodSettings"/>.
    /// Specifies the expected length and whether checksum validation applies.
    /// </summary>
    public class PaymentMethodSettingsCardNumber
    {
        /// <summary>
        /// Expected length of the card number (e.g. <c>16</c>).
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Indicates whether the card number can be validated using a checksum
        /// algorithm (usually Luhn). Typical values: <c>standard</c>,
        /// <c>none</c>.
        /// </summary>
        public string Validation { get; set; }
    }
}
