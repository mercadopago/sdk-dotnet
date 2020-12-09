namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// Financial institution processing this payment method.
    /// </summary>
    public class PaymentMethodFinancialInstitutions
    {
        /// <summary>
        /// External financial institution identifier (e.g.: company id for atm)
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Descriptive financial institution name.
        /// </summary>
        public string Description { get; set; }
    }
}
