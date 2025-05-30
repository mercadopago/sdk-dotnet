// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Automatic Payments class.
    /// </summary>
    public class OrderAutomaticPayments
    {
        /// <summary>
        /// Payment Profile ID.
        /// </summary>
        public string PaymentProfileId { get; set; }

        /// <summary>
        /// Schedule Date.
        /// </summary>
        public string ScheduleDate { get; set; }

        /// <summary>
        /// Due Date.
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Retries.
        /// </summary>
        public int? Retries { get; set; }
    }
}
