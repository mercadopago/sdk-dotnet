namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Track to be executed during the users's interaction in the Checkout flow.
    /// </summary>
    public class PreferenceTrackRequest
    {
        /// <summary>
        /// Track type (<c>google_ad</c> or <c>facebook_ad</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Values according the track type.
        /// </summary>
        public PreferenceTrackValuesRequest Values { get; set; }
    }
}
