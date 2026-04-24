// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration for automatic (recurring) payment execution within an order transaction.
    /// Used to schedule payments that are charged automatically on a defined date.
    /// </summary>
    /// <seealso cref="OrderPaymentRequest"/>
    public class OrderAutomaticPaymentRequest
    {
        /// <summary>
        /// Identifier of the payment profile used for automatic billing.
        /// </summary>
        public string PaymentProfileId { get; set; }

        /// <summary>
        /// Date when the automatic payment is scheduled to be executed (ISO 8601 format).
        /// </summary>
        public string ScheduleDate { get; set; }

        /// <summary>
        /// Due date for the automatic payment. If the payment is not completed by this date,
        /// retry logic may apply (ISO 8601 format).
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Number of retry attempts allowed if the automatic payment fails.
        /// </summary>
        public int? Retries { get; set; }
    }

}
