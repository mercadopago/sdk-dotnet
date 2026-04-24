namespace MercadoPago.Client.Preapproval
{
    using System;

    /// <summary>
    /// Request DTO that defines the automatic recurring billing schedule when creating
    /// a new preapproval (subscription). Used as the <see cref="PreapprovalCreateRequest.AutoRecurring"/>
    /// property to configure how often and how much the subscriber is charged.
    /// </summary>
    public class PreApprovalAutoRecurringCreateRequest
    {
        /// <summary>
        /// ISO 4217 currency code for the recurring charges (e.g., <c>"BRL"</c>, <c>"ARS"</c>, <c>"MXN"</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Amount to charge in each billing cycle, expressed in the currency specified by <see cref="CurrencyId"/>.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Number of <see cref="FrequencyType"/> units between each charge
        /// (e.g., <c>1</c> with <see cref="FrequencyType"/> = <c>"months"</c> means monthly billing).
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// Unit of time for the billing frequency. Accepted values are <c>"days"</c> or <c>"months"</c>.
        /// </summary>
        public string FrequencyType { get; set; }

        /// <summary>
        /// Date when recurring billing should begin. If <c>null</c>, billing starts immediately upon subscription approval.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Date when recurring billing should stop. If <c>null</c>, the subscription continues indefinitely.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
