namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Identifies a specific payment method to exclude from the Checkout Pro flow.
    /// Used within <see cref="PreferencePaymentMethodsRequest.ExcludedPaymentMethods"/>.
    /// </summary>
    public class PreferencePaymentMethodRequest
    {
        /// <summary>
        /// Payment method ID (e.g., <c>"visa"</c>, <c>"master"</c>, <c>"amex"</c>).
        /// </summary>
        public string Id { get; set; }
    }
}
