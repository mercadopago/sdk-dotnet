namespace MercadoPago.Client.Preapproval
{
    /// <summary>
    /// Data to create a Preapproval.
    /// </summary>
    public class PreapprovalCreateRequest
    {
        /// <summary>
        /// Payer email.
        /// </summary>
        public string PayerEmail { get; set; }

        /// <summary>
        /// Return URL.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Seller ID.
        /// </summary>
        public long? CollectorId { get; set; }

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
        public PreApprovalAutoRecurringCreateRequest AutoRecurring { get; set; }
    }
}
