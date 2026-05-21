namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Breakdown of transaction amounts for the collector (seller) and the payer (buyer).
    /// Used to specify currency and amount details for each party in the transaction.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    /// <seealso cref="PreferenceUserAmountsRequest"/>
    public class PreferenceAmountsRequest
    {
        /// <summary>
        /// Amount and currency details for the collector (seller) side of the transaction.
        /// </summary>
        /// <seealso cref="PreferenceUserAmountsRequest"/>
        public PreferenceUserAmountsRequest Collector { get; set; }

        /// <summary>
        /// Amount and currency details for the payer (buyer) side of the transaction.
        /// </summary>
        /// <seealso cref="PreferenceUserAmountsRequest"/>
        public PreferenceUserAmountsRequest Payer { get; set; }
    }
} 