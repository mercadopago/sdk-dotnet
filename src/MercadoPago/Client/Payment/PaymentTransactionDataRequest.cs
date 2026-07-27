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

        /// <summary>
        /// <c>true</c> if this is the first transaction stored under a
        /// CREDENTIAL_ON_FILE agreement; otherwise, <c>false</c>.
        /// </summary>
        public bool FirstTransaction { get; set; }

        /// <summary>
        /// Storage stage of the credential-on-file agreement.
        /// Use <c>"store"</c> when storing the credential for the first time,
        /// or <c>"stored"</c> for subsequent uses of a stored credential.
        /// </summary>
        public string Storage { get; set; }

        /// <summary>
        /// Indicates who initiated the transaction.
        /// Use <c>"customer"</c> for customer-initiated transactions (CIT)
        /// or <c>"merchant"</c> for merchant-initiated transactions (MIT).
        /// </summary>
        public string TransactionInitiator { get; set; }

        /// <summary>
        /// Reference to a related resource within the CREDENTIAL_ON_FILE flow,
        /// such as a mandate or agreement identifier.
        /// </summary>
        /// <seealso cref="PaymentReferenceRequest"/>
        public PaymentReferenceRequest Reference { get; set; }
    }
}