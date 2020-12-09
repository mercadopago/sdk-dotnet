namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Payment method settings.
    /// </summary>
    public class PaymentMethodSettings
    {
        /// <summary>
        /// Bin settings.
        /// </summary>
        public PaymentMethodSettingsBin Bin { get; set; }

        /// <summary>
        /// Card number settings.
        /// </summary>
        public PaymentMethodSettingsCardNumber CardNumber { get; set; }

        /// <summary>
        /// Security code settings.
        /// </summary>
        public PaymentMethodSettingsSecurityCode SecurityCode { get; set; }
    }
}
