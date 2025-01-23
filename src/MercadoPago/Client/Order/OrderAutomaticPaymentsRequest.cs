namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Automatic Payments class.
    /// </summary>
    public class OrderAutomaticPaymentRequest
    {
        /// <summary>
        /// Payment Profile Id.
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