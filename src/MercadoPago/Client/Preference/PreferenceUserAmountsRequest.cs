namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// User amounts request within PreferenceAmountsRequest.
    /// </summary>
    public class PreferenceUserAmountsRequest
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