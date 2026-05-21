namespace MercadoPago.Client.Preapproval
{
    /// <summary>
    /// Request DTO for updating an existing preapproval (subscription) in the MercadoPago
    /// Subscriptions API. Used with <see cref="PreapprovalClient.UpdateAsync"/>
    /// and <see cref="PreapprovalClient.Update"/>.
    /// Only set the properties you want to change; unset properties remain unchanged.
    /// </summary>
    public class PreapprovalUpdateRequest
    {
        /// <summary>
        /// Updated URL the subscriber is redirected to after approving or declining the subscription.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Updated human-readable title or description displayed to the subscriber
        /// (e.g., <c>"Monthly Premium Plan - Updated"</c>).
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Updated integrator-defined reference that links this subscription to an entity
        /// in the integrator's system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Updated subscription status (e.g., <c>"paused"</c>, <c>"cancelled"</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Updated automatic recurring billing configuration. Only the amount and date
        /// boundaries can be modified; see <see cref="PreApprovalAutoRecurringUpdateRequest"/>.
        /// </summary>
        public PreApprovalAutoRecurringUpdateRequest AutoRecurring { get; set; }
    }
}
