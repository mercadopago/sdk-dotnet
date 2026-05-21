namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents a payment type that can be excluded from a <see cref="Preference"/>
    /// checkout flow via <see cref="PreferencePaymentMethods"/>.
    /// </summary>
    public class PreferencePaymentType
    {
        /// <summary>
        /// Identifier of the payment type (e.g., <c>credit_card</c>, <c>debit_card</c>, <c>ticket</c>, <c>bank_transfer</c>).
        /// </summary>
        public string Id { get; set; }
    }
}
