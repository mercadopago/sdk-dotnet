namespace MercadoPago.Client.Preapproval
{
    using System;

    /// <summary>
    /// Recurring data.
    /// </summary>
    public class PreApprovalAutoRecurringUpdateRequest
    {
        /// <summary>
        /// Recurring amount.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Recurring start date.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Recurring end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
