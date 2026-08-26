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

        /// <summary>
        /// Subscription and invoice information for the automatic payment.
        /// </summary>
        public OrderAutomaticPaymentsSubscriptionRequest Subscription { get; set; }
    }

    /// <summary>
    /// Subscription details associated with an automatic payment request.
    /// </summary>
    public class OrderAutomaticPaymentsSubscriptionRequest
    {
        /// <summary>Subscription identifier.</summary>
        public string Id { get; set; }
        /// <summary>Position of this payment within the subscription.</summary>
        public OrderSubscriptionSequenceRequest Sequence { get; set; }
        /// <summary>Invoice information for this subscription payment.</summary>
        public OrderAutomaticPaymentsInvoiceRequest Invoice { get; set; }
    }
    /// <summary>Invoice details associated with an automatic payment subscription.</summary>
    public class OrderAutomaticPaymentsInvoiceRequest
    {
        /// <summary>Invoice identifier.</summary>
        public string Id { get; set; }
        /// <summary>Invoice billing date in ISO 8601 format.</summary>
        public string BillingDate { get; set; }
        /// <summary>Billing period for the invoice.</summary>
        public OrderAutomaticPaymentsPeriodRequest Period { get; set; }
    }
    /// <summary>Billing-period details for an automatic payment invoice.</summary>
    public class OrderAutomaticPaymentsPeriodRequest
    {
        /// <summary>Number of period units.</summary>
        public int? Interval { get; set; }
        /// <summary>Unit of the billing period.</summary>
        public string Type { get; set; }
    }

}
