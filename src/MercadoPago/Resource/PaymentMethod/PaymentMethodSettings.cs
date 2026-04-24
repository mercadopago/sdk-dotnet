namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Validation and formatting settings for a <see cref="PaymentMethod"/>.
    /// Each element in the <see cref="PaymentMethod.Settings"/> list
    /// describes BIN patterns, card number constraints, and security code
    /// rules for a subset of cards supported by that payment method.
    /// </summary>
    public class PaymentMethodSettings
    {
        /// <summary>
        /// BIN (Bank Identification Number) pattern rules that determine
        /// which card ranges are accepted or excluded.
        /// </summary>
        public PaymentMethodSettingsBin Bin { get; set; }

        /// <summary>
        /// Card number length and validation rules.
        /// </summary>
        public PaymentMethodSettingsCardNumber CardNumber { get; set; }

        /// <summary>
        /// Security code (CVV/CVC) requirements and location.
        /// </summary>
        public PaymentMethodSettingsSecurityCode SecurityCode { get; set; }
    }
}
