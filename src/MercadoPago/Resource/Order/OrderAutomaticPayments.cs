// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the automatic (recurring) payment configuration for an <see cref="OrderPayment"/>,
    /// including scheduling, due dates, and retry policies.
    /// </summary>
    public class OrderAutomaticPayments
    {
        /// <summary>
        /// Identifier of the payment profile that defines the recurring payment rules and card on file.
        /// </summary>
        public string PaymentProfileId { get; set; }

        /// <summary>
        /// ISO 8601 date when the automatic payment is scheduled to be processed.
        /// </summary>
        public string ScheduleDate { get; set; }

        /// <summary>
        /// ISO 8601 date by which the automatic payment must be completed before it is considered overdue.
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Number of retry attempts allowed if the automatic payment fails on the scheduled date.
        /// </summary>
        public int? Retries { get; set; }
    }
}
