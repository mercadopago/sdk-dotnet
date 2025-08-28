namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Amounts response from Preference.
    /// </summary>
    public class PreferenceAmountsResponse
    {
        /// <summary>
        /// Collector amounts information.
        /// </summary>
        public PreferenceUserAmountsResponse Collector { get; set; }

        /// <summary>
        /// Payer amounts information.
        /// </summary>
        public PreferenceUserAmountsResponse Payer { get; set; }
    }
} 