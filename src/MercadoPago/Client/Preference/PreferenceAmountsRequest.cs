namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Amounts request within Preference.
    /// </summary>
    public class PreferenceAmountsRequest
    {
        /// <summary>
        /// Collector amounts information.
        /// </summary>
        public PreferenceUserAmountsRequest Collector { get; set; }

        /// <summary>
        /// Payer amounts information.
        /// </summary>
        public PreferenceUserAmountsRequest Payer { get; set; }
    }
} 