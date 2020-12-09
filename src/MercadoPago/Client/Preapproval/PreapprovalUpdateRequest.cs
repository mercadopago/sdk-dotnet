namespace MercadoPago.Client.Preapproval
{
    /// <summary>
    /// Data to update a Preapproval.
    /// </summary>
    public class PreapprovalUpdateRequest
    {
        /// <summary>
        /// Return URL.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Preapproval title.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Preapproval reference value.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Preapproval status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Recurring data.
        /// </summary>
        public PreApprovalAutoRecurringUpdateRequest AutoRecurring { get; set; }
    }
}
