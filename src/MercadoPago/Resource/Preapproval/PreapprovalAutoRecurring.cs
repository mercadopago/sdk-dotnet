namespace MercadoPago.Resource.PreApproval
{
    using System;

    /// <summary>
    /// Recurring billing configuration for a <see cref="Preapproval"/>
    /// subscription. Defines how often the payer is charged, the amount, and
    /// the billing period.
    /// </summary>
    public class PreapprovalAutoRecurring
    {
        /// <summary>
        /// ISO 4217 currency code for the recurring charges (e.g. <c>ARS</c>,
        /// <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Amount charged on each billing cycle.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Number of <see cref="FrequencyType"/> units between each charge
        /// (e.g. <c>1</c> combined with <c>months</c> means monthly billing).
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// Time unit for the billing frequency. Possible values:
        /// <c>days</c>, <c>months</c>.
        /// </summary>
        public string FrequencyType { get; set; }

        /// <summary>
        /// Date and time when the first recurring charge should be attempted.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date and time after which no further recurring charges will be
        /// attempted. If <c>null</c>, the subscription has no end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
