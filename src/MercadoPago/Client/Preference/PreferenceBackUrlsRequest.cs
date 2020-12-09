namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Back URLs.
    /// </summary>
    public class PreferenceBackUrlsRequest
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
