using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a single payment within an <see cref="OrderTransaction"/>, including its status,
    /// amounts, payment method, retry attempts, and related subscription or stored credential data.
    /// </summary>
    public class OrderPayment
    {
        /// <summary>
        /// Unique identifier assigned to this payment by MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Reference identifier used to correlate this payment with external systems or retries.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Current processing status of the payment (e.g., "approved", "rejected", "pending", "cancelled").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed reason for the current <see cref="Status"/>, providing context such as rejection causes.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Sequential number indicating which payment attempt this represents within the order.
        /// </summary>
        public int? AttemptNumber { get; set; }

        /// <summary>
        /// List of <see cref="OrderAttempt"/> records tracking each individual processing attempt for this payment.
        /// </summary>
        public IList<OrderAttempt> Attempts { get; set; }

        /// <summary>
        /// ISO 8601 timestamp indicating the date after which this payment expires and can no longer be processed.
        /// </summary>
        public string DateOfExpiration { get; set; }

        /// <summary>
        /// Duration or ISO 8601 timestamp defining how long this payment remains valid for completion.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Requested payment amount in the order currency.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Amount that has been successfully collected from the payer for this payment.
        /// </summary>
        public string PaidAmount { get; set; }

        /// <summary>
        /// Payment method details including card, ticket, or transfer information.
        /// See <see cref="OrderPaymentMethod"/> for all available fields.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Configuration for recurring automatic payments, including schedule and retry settings.
        /// See <see cref="OrderAutomaticPayments"/>.
        /// </summary>
        public OrderAutomaticPayments AutomaticPayments { get; set; }

        /// <summary>
        /// Credential-on-file data used for merchant-initiated or recurring transactions.
        /// See <see cref="OrderStoredCredential"/>.
        /// </summary>
        public OrderStoredCredential StoredCredential { get; set; }

        /// <summary>
        /// Subscription billing data associated with this payment, including invoice and sequence information.
        /// See <see cref="OrderSubscriptionData"/>.
        /// </summary>
        public OrderSubscriptionData SubscriptionData { get; set; }

        /// <summary>
        /// Cumulative amount that has been refunded back to the payer from this payment.
        /// </summary>
        public string RefundedAmount { get; set; }

        /// <summary>
        /// Payment provider or acquirer that processed this payment (e.g., the financial institution name).
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// List of <see cref="OrderPaymentDiscount"/> entries representing discounts applied to this specific payment.
        /// </summary>
        public IList<OrderPaymentDiscount> Discounts { get; set; }
    }
}
