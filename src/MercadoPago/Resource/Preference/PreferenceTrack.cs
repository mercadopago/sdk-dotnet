namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Track to be executed during the users's interaction in the Checkout flow.
    /// </summary>
    public class PreferenceTrack
    {
        /// <summary>
        /// Track type (<c>google_ad</c> or <c>facebook_ad</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Values according the track type.
        /// </summary>
        public PreferenceTrackValues Values { get; set; }
    }
}
