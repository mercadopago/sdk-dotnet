namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Counter currency information for cross-border payment scenarios
    /// within a <see cref="PaymentCreateRequest"/>. Specifies the currency
    /// used on the opposite side of the transaction.
    /// </summary>
    public class PaymentCounterCurrencyRequest
    {
        /// <summary>
        /// ISO 4217 currency code (e.g., "USD", "BRL", "ARS").
        /// </summary>
        public string CurrencyId { get; set; }
    }
} 