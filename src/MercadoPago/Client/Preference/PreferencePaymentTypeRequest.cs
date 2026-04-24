namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Identifies a payment type to exclude from the Checkout Pro flow.
    /// Used within <see cref="PreferencePaymentMethodsRequest.ExcludedPaymentTypes"/>.
    /// </summary>
    public class PreferencePaymentTypeRequest
    {
        /// <summary>
        /// Payment type ID (e.g., <c>"credit_card"</c>, <c>"debit_card"</c>, <c>"ticket"</c>, <c>"atm"</c>).
        /// </summary>
        public string Id { get; set; }
    }
}
