namespace MercadoPago.Client.PreApprovalPlan
{
    /// <summary>
    /// Request body for updating an existing subscription plan
    /// via <see cref="PreApprovalPlanClient.UpdateAsync"/> /
    /// <see cref="PreApprovalPlanClient.Update"/>.
    /// Only the properties that are set will be modified.
    /// </summary>
    public class PreApprovalPlanUpdateRequest
    {
        /// <summary>
        /// New title for the plan.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// New back URL for the plan.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Updated recurring billing configuration.
        /// </summary>
        public PreApprovalPlanAutoRecurringRequest AutoRecurring { get; set; }

        /// <summary>
        /// New status of the plan. Use <c>cancelled</c> to deactivate it.
        /// </summary>
        public string Status { get; set; }
    }
}
