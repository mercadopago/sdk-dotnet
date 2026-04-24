namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Redirect URLs where the buyer is sent after completing the Checkout Pro flow.
    /// These URLs correspond to the three possible payment outcomes. Required when
    /// <see cref="PreferenceRequest.AutoReturn"/> is set.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    public class PreferenceBackUrlsRequest
    {
        /// <summary>
        /// URL to redirect the buyer to when the payment is approved.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// URL to redirect the buyer to when the payment is pending review or processing.
        /// </summary>
        public string Pending { get; set; }

        /// <summary>
        /// URL to redirect the buyer to when the payment is rejected.
        /// </summary>
        public string Failure { get; set; }
    }
}
