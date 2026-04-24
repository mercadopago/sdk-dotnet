namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the counter-currency information returned by the API for a <see cref="Preference"/>
    /// when the transaction involves a cross-currency conversion.
    /// </summary>
    public class PreferenceCounterCurrencyResponse
    {
        /// <summary>
        /// ISO 4217 currency code of the counter currency (e.g., <c>USD</c>, <c>EUR</c>).
        /// </summary>
        public string CurrencyId { get; set; }
    }
} 