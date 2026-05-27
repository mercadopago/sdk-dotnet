namespace MercadoPago.Client.PreApprovalPlan
{
    /// <summary>
    /// Request body for creating a new subscription plan
    /// via <see cref="PreApprovalPlanClient.CreateAsync"/> /
    /// <see cref="PreApprovalPlanClient.Create"/>.
    /// </summary>
    public class PreApprovalPlanCreateRequest
    {
        /// <summary>
        /// Short descriptive title of the plan, visible to subscribers during checkout.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// URL to which the payer is redirected after completing the subscription checkout.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Free-text external reference for correlating the plan with your own system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Recurring billing configuration for this plan (frequency, currency, amount).
        /// </summary>
        public PreApprovalPlanAutoRecurringRequest AutoRecurring { get; set; }
    }
}
