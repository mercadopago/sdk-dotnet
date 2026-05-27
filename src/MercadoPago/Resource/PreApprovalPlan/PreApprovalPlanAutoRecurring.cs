namespace MercadoPago.Resource.PreApprovalPlan
{
    /// <summary>
    /// Defines the recurring billing configuration for a subscription plan,
    /// including frequency, currency, and charge amount.
    /// </summary>
    public class PreApprovalPlanAutoRecurring
    {
        /// <summary>
        /// Billing frequency unit (e.g. <c>days</c>, <c>months</c>).
        /// </summary>
        public string FrequencyType { get; set; }

        /// <summary>
        /// Number of frequency units between each billing cycle.
        /// </summary>
        public int? Frequency { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the recurring charge (e.g. <c>BRL</c>, <c>ARS</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Amount charged to the subscriber on each billing cycle.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Maximum number of billing cycles. <c>null</c> means indefinite.
        /// </summary>
        public int? Repetitions { get; set; }

        /// <summary>
        /// Indicates whether free trial is enabled for this plan.
        /// </summary>
        public bool? HasFreeTrial { get; set; }

        /// <summary>
        /// Duration of the free trial period.
        /// </summary>
        public int? FreeTrial { get; set; }

        /// <summary>
        /// Free trial period unit (e.g. <c>days</c>, <c>months</c>).
        /// </summary>
        public string FreeTrialFrequencyType { get; set; }
    }
}
