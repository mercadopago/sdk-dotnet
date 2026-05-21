namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the redirect URLs configured in a <see cref="Preference"/> that the buyer
    /// is sent to after completing (or failing) the Checkout Pro flow.
    /// </summary>
    public class PreferenceBackUrls
    {
        /// <summary>
        /// URL where the buyer is redirected when the payment succeeds.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// URL where the buyer is redirected when the payment is pending review or processing.
        /// </summary>
        public string Pending { get; set; }

        /// <summary>
        /// URL where the buyer is redirected when the payment fails or is rejected.
        /// </summary>
        public string Failure { get; set; }
    }
}
