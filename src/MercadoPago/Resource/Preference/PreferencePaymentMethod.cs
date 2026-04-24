namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents a specific payment method that can be excluded from or set as default
    /// in a <see cref="Preference"/> checkout flow via <see cref="PreferencePaymentMethods"/>.
    /// </summary>
    public class PreferencePaymentMethod
    {
        /// <summary>
        /// Identifier of the payment method (e.g., <c>visa</c>, <c>master</c>, <c>amex</c>, <c>pix</c>).
        /// </summary>
        public string Id { get; set; }
    }
}
