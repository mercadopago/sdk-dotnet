namespace MercadoPago.Client.Preapproval
{
    using System;

    /// <summary>
    /// Request DTO for modifying the automatic recurring billing schedule of an existing
    /// preapproval (subscription). Used as the <see cref="PreapprovalUpdateRequest.AutoRecurring"/>
    /// property. Only set the fields you want to change; unset fields remain unchanged.
    /// </summary>
    /// <remarks>
    /// Unlike <see cref="PreApprovalAutoRecurringCreateRequest"/>, the currency and frequency
    /// cannot be changed after creation; only the amount and date boundaries are updatable.
    /// </remarks>
    public class PreApprovalAutoRecurringUpdateRequest
    {
        /// <summary>
        /// Updated amount to charge in each billing cycle.
        /// Set to <c>null</c> to leave the current amount unchanged.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Updated date when recurring billing should begin.
        /// Set to <c>null</c> to leave the current start date unchanged.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Updated date when recurring billing should stop.
        /// Set to <c>null</c> to leave the current end date unchanged.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
