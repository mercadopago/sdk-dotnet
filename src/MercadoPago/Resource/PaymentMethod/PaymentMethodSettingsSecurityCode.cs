namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Security code (CVV/CVC) rules within a
    /// <see cref="PaymentMethodSettings"/>. Describes whether the code is
    /// required, its length, and its physical position on the card.
    /// </summary>
    public class PaymentMethodSettingsSecurityCode
    {
        /// <summary>
        /// Indicates whether the security code is required. Typical values:
        /// <c>mandatory</c>, <c>optional</c>.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Expected number of digits in the security code (typically 3 or 4).
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Physical location of the security code on the card
        /// (e.g. <c>back</c>, <c>front</c>).
        /// </summary>
        public string CardLocation { get; set; }
    }
}
