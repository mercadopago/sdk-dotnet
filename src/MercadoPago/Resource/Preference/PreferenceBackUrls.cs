namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Back URLs from <see cref="Preference"/>.
    /// </summary>
    public class PreferenceBackUrls
    {
        /// <summary>
        /// URL to return when the payment succeed.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// URL to return when the payment is pending.
        /// </summary>
        public string Pending { get; set; }

        /// <summary>
        /// URL to return when the payment fail.
        /// </summary>
        public string Failure { get; set; }
    }
}
