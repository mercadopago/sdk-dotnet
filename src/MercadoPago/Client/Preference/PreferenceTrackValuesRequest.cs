namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Parameter values for advertising conversion tracks in the Checkout Pro flow.
    /// For Google Ads, provide <see cref="ConversionId"/> and <see cref="ConversionLabel"/>.
    /// For Facebook Pixel, provide <see cref="PixelId"/>.
    /// </summary>
    /// <seealso cref="PreferenceTrackRequest"/>
    public class PreferenceTrackValuesRequest
    {
        /// <summary>
        /// Google Ads conversion ID used with the GTM Google Ads Conversion Tracking tag.
        /// Required when <see cref="PreferenceTrackRequest.Type"/> is <c>"google_ad"</c>.
        /// </summary>
        public string ConversionId { get; set; }

        /// <summary>
        /// Google Ads conversion label used with the GTM Google Ads Conversion Tracking tag.
        /// Required when <see cref="PreferenceTrackRequest.Type"/> is <c>"google_ad"</c>.
        /// </summary>
        public string ConversionLabel { get; set; }

        /// <summary>
        /// Facebook Pixel ID for conversion tracking.
        /// Required when <see cref="PreferenceTrackRequest.Type"/> is <c>"facebook_ad"</c>.
        /// </summary>
        public string PixelId { get; set; }
    }
}
