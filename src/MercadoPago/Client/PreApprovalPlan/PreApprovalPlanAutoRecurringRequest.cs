namespace MercadoPago.Client.PreApprovalPlan
{
    /// <summary>
    /// Recurring billing configuration included in create and update requests
    /// for a subscription plan.
    /// </summary>
    public class PreApprovalPlanAutoRecurringRequest
    {
        /// <summary>
        /// Billing frequency unit. Accepted values: <c>days</c>, <c>months</c>.
        /// </summary>
        public string FrequencyType { get; set; }

        /// <summary>
        /// Number of frequency units between each billing cycle (e.g. <c>1</c> month).
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
        /// Maximum number of billing cycles. Omit for indefinite billing.
        /// </summary>
        public int? Repetitions { get; set; }
    }
}
