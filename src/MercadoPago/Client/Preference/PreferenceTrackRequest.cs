namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Advertising conversion track executed during the buyer's interaction in the Checkout Pro flow.
    /// Supports Google Ads and Facebook Pixel integrations.
    /// </summary>
    /// <seealso cref="PreferenceTrackValuesRequest"/>
    public class PreferenceTrackRequest
    {
        /// <summary>
        /// Track type. Valid values are <c>"google_ad"</c> for Google Ads conversion tracking
        /// or <c>"facebook_ad"</c> for Facebook Pixel tracking.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tracking parameter values specific to the selected <see cref="Type"/>.
        /// </summary>
        /// <seealso cref="PreferenceTrackValuesRequest"/>
        public PreferenceTrackValuesRequest Values { get; set; }
    }
}
