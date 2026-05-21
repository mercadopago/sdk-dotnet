namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the computed amounts for a specific user (collector or payer) within
    /// a <see cref="PreferenceAmountsResponse"/>. Contains the currency and transaction total.
    /// </summary>
    public class PreferenceUserAmountsResponse
    {
        /// <summary>
        /// ISO 4217 currency code for the transaction amount (e.g., <c>ARS</c>, <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Total transaction amount for this user, in the currency specified by <see cref="CurrencyId"/>.
        /// </summary>
        public decimal? Transaction { get; set; }
    }
} 