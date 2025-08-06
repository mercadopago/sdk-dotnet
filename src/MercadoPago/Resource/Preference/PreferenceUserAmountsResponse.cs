namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// User amounts response within PreferenceAmountsResponse.
    /// </summary>
    public class PreferenceUserAmountsResponse
    {
        /// <summary>
        /// Currency identifier.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        public decimal? Transaction { get; set; }
    }
} 