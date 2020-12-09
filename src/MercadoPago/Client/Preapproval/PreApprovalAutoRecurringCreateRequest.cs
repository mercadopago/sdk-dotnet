namespace MercadoPago.Client.Preapproval
{
    using System;

    /// <summary>
    /// Recurring data.
    /// </summary>
    public class PreApprovalAutoRecurringCreateRequest
    {
        /// <summary>
        /// Currency ID.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Recurring amount.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Recurring frequency.
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// Recurring frequency type (days or months).
        /// </summary>
        public string FrequencyType { get; set; }

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
