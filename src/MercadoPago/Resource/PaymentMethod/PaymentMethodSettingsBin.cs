namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// BIN (Bank Identification Number) pattern rules within a
    /// <see cref="PaymentMethodSettings"/>. These regular expressions define
    /// which card BIN ranges are accepted, excluded, or eligible for
    /// installment payments.
    /// </summary>
    public class PaymentMethodSettingsBin
    {
        /// <summary>
        /// Regular expression that matches the accepted BIN ranges for this
        /// payment method setting.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Regular expression that matches BIN ranges explicitly excluded
        /// from this payment method setting.
        /// </summary>
        public string ExclusionPattern { get; set; }

        /// <summary>
        /// Regular expression that matches BIN ranges eligible for payments
        /// with more than one installment.
        /// </summary>
        public string InstallmentsPattern { get; set; }
    }
}
