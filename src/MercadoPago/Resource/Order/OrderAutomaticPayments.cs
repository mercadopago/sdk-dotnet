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

        /// <summary>
        /// Subscription and invoice information returned for the automatic payment.
        /// </summary>
        public OrderAutomaticPaymentsSubscription Subscription { get; set; }
    }

    /// <summary>Subscription details returned for an automatic payment.</summary>
    public class OrderAutomaticPaymentsSubscription
    {
        /// <summary>Subscription identifier.</summary>
        public string Id { get; set; }
        /// <summary>Position of this payment within the subscription.</summary>
        public OrderSubscriptionSequence Sequence { get; set; }
        /// <summary>Invoice information for this subscription payment.</summary>
        public OrderAutomaticPaymentsInvoice Invoice { get; set; }
    }
    /// <summary>Invoice details returned for an automatic payment subscription.</summary>
    public class OrderAutomaticPaymentsInvoice
    {
        /// <summary>Invoice identifier.</summary>
        public string Id { get; set; }
        /// <summary>Invoice billing date in ISO 8601 format.</summary>
        public string BillingDate { get; set; }
        /// <summary>Billing period for the invoice.</summary>
        public OrderAutomaticPaymentsPeriod Period { get; set; }
    }
    /// <summary>Billing-period details returned for an automatic payment invoice.</summary>
    public class OrderAutomaticPaymentsPeriod
    {
        /// <summary>Number of period units.</summary>
        public int? Interval { get; set; }
        /// <summary>Unit of the billing period.</summary>
        public string Type { get; set; }
    }
}
