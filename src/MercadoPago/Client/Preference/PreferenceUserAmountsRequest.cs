namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Currency and transaction amount for one party (collector or payer) in the preference.
    /// Used within <see cref="PreferenceAmountsRequest"/> to define per-party amounts.
    /// </summary>
    public class PreferenceUserAmountsRequest
    {
        /// <summary>
        /// Currency identifier in ISO 4217 format (e.g., <c>"ARS"</c>, <c>"BRL"</c>, <c>"USD"</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Transaction amount for this party in the specified currency.
        /// </summary>
        public decimal? Transaction { get; set; }
    }
} 