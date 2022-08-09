namespace MercadoPago.Client.Payment
{
        using System;

    /// <summary>
    /// Payment's transaction data.
    /// </summary>
    public class PaymentTransactionDataRequest
    {

        /// <summary>
        /// First time use.
        /// </summary>
        public bool FirstTimeUse { get; set; }

        /// <summary>
        /// Subscription sequence.
        /// </summary>
        public PaymentSubscriptionSequenceRequest SubscriptionSequence { get; set; }

        /// <summary>
        /// Subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Plan id.
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// Invoice id.
        /// </summary>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Invoice period.
        /// </summary>
        public PaymentInvoicePeriodRequest InvoicePeriod { get; set; }

        /// <summary>
        /// Invoice period.
        /// </summary>
        public PaymentPaymentReferenceRequest PaymentReference { get; set; }

         /// <summary>
        /// Billing date.
        /// </summary>
        public string BillingDate { get; set; }

    }
}