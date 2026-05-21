namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Transaction data associated with a <see cref="PaymentPointOfInteractionRequest"/>.
    /// Contains subscription, billing, and user presence details for recurring
    /// or subscription-based payment flows.
    /// </summary>
    public class PaymentTransactionDataRequest
    {

        /// <summary>
        /// <c>true</c> if this is the first transaction using this payment method
        /// in the subscription; otherwise, <c>false</c>.
        /// </summary>
        public bool FirstTimeUse { get; set; }

        /// <summary>
        /// Subscription sequence details, including the current payment number
        /// and total expected payments.
        /// </summary>
        /// <seealso cref="PaymentSubscriptionSequenceRequest"/>
        public PaymentSubscriptionSequenceRequest SubscriptionSequence { get; set; }

        /// <summary>
        /// Unique identifier of the subscription this payment belongs to.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Invoice period details for recurring billing, including period duration and type.
        /// </summary>
        /// <seealso cref="PaymentInvoicePeriodRequest"/>
        public PaymentInvoicePeriodRequest InvoicePeriod { get; set; }

        /// <summary>
        /// Reference to a previous payment in the subscription series.
        /// </summary>
        /// <seealso cref="PaymentPaymentReferenceRequest"/>
        public PaymentPaymentReferenceRequest PaymentReference { get; set; }

        /// <summary>
        /// Date on which the billing occurs, formatted as a string (e.g., "2024-01-15").
        /// </summary>
        public string BillingDate { get; set; }

        /// <summary>
        /// <c>true</c> if the user (cardholder) is present during the transaction;
        /// otherwise, <c>false</c>. Affects fraud analysis rules.
        /// </summary>
        public bool? UserPresent { get; set; }
    }
}