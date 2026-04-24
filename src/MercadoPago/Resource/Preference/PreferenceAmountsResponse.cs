namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the computed amounts breakdown returned by the API for a <see cref="Preference"/>.
    /// Separates the transaction totals into what the seller receives and what the buyer pays.
    /// </summary>
    public class PreferenceAmountsResponse
    {
        /// <summary>
        /// Amount information for the seller (collector), including the currency and transaction total they receive.
        /// </summary>
        public PreferenceUserAmountsResponse Collector { get; set; }

        /// <summary>
        /// Amount information for the buyer (payer), including the currency and transaction total they pay.
        /// </summary>
        public PreferenceUserAmountsResponse Payer { get; set; }
    }
} 