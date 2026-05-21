namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Counter-currency configuration for cross-border payments. Specifies the currency in
    /// which the buyer pays when it differs from the seller's receiving currency.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    public class PreferenceCounterCurrencyRequest
    {
        /// <summary>
        /// Currency identifier in ISO 4217 format (e.g., <c>"USD"</c>, <c>"BRL"</c>).
        /// </summary>
        public string CurrencyId { get; set; }
    }
} 