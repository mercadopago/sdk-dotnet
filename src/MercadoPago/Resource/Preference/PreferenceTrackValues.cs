namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Values of tracks to be executed during the users's interaction in the
    /// Checkout flow.
    /// </summary>
    public class PreferenceTrackValues
    {
        /// <summary>
        /// <c>conversion_id</c> for GTM's Google Ads Conversion Tracking tag.
        /// </summary>
        public string ConversionId { get; set; }

        /// <summary>
        /// <c>conversion_label</c> for GTM's Google Ads Conversion Tracking tag.
        /// </summary>
        public string ConversionLabel { get; set; }

        /// <summary>
        /// <c>pixel_id</c> for Facebook Pixel.
        /// </summary>
        public string PixelId { get; set; }
    }
}
