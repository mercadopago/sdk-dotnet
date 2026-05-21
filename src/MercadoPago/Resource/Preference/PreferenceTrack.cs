namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents a tracking pixel or conversion tag executed during the buyer's interaction
    /// in the Checkout Pro flow. Used to integrate with advertising platforms for conversion tracking.
    /// </summary>
    public class PreferenceTrack
    {
        /// <summary>
        /// Type of tracking integration. Supported values: <c>google_ad</c> for Google Ads
        /// conversion tracking, or <c>facebook_ad</c> for Facebook Pixel tracking.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Configuration values specific to the tracking type (e.g., conversion IDs, pixel IDs).
        /// </summary>
        public PreferenceTrackValues Values { get; set; }
    }
}
