namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the configuration values for a <see cref="PreferenceTrack"/>,
    /// containing the identifiers needed for Google Ads or Facebook Pixel conversion tracking.
    /// </summary>
    public class PreferenceTrackValues
    {
        /// <summary>
        /// Google Ads conversion ID, used with GTM's Google Ads Conversion Tracking tag.
        /// Required when the <see cref="PreferenceTrack.Type"/> is <c>google_ad</c>.
        /// </summary>
        public string ConversionId { get; set; }

        /// <summary>
        /// Google Ads conversion label, used with GTM's Google Ads Conversion Tracking tag.
        /// Required when the <see cref="PreferenceTrack.Type"/> is <c>google_ad</c>.
        /// </summary>
        public string ConversionLabel { get; set; }

        /// <summary>
        /// Facebook Pixel identifier, used for Facebook conversion tracking.
        /// Required when the <see cref="PreferenceTrack.Type"/> is <c>facebook_ad</c>.
        /// </summary>
        public string PixelId { get; set; }
    }
}
