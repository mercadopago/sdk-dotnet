// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents a single payment within an order transaction. Each transaction can contain
    /// one or more payments, each with its own amount, method, and optional recurring-payment settings.
    /// Also used as the request body when updating a transaction via
    /// <see cref="OrderTransactionClient.Update(string, string, OrderPaymentRequest, RequestOptions)"/>.
    /// </summary>
    /// <seealso cref="OrderTransactionRequest"/>
    /// <seealso cref="OrderPaymentMethodRequest"/>
    public class OrderPaymentRequest : IdempotentRequest
    {
        /// <summary>
        /// Payment amount expressed as a decimal string (e.g., "150.00").
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Expiration time for this payment in ISO 8601 format.
        /// After this time the payment can no longer be completed.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Absolute date and time (ISO 8601) after which this payment can no longer be collected.
        /// Distinct from <see cref="ExpirationTime"/> which is a relative duration or TTL.
        /// Type: string (ISO 8601, e.g. "2026-06-01T00:00:00.000-04:00").
        /// </summary>
        public string DateOfExpiration { get; set; }

        /// <summary>
        /// Payment method details including method type, card token, and installments.
        /// </summary>
        /// <seealso cref="OrderPaymentMethodRequest"/>
        public OrderPaymentMethodRequest PaymentMethod { get; set; }

        /// <summary>
        /// Automatic (recurring) payment configuration for scheduled billing.
        /// </summary>
        /// <seealso cref="OrderAutomaticPaymentRequest"/>
        public OrderAutomaticPaymentRequest AutomaticPayments { get; set; }

        /// <summary>
        /// Stored credential information for merchant-initiated or cardholder-initiated recurring transactions.
        /// </summary>
        /// <seealso cref="OrderStoredCredentialRequest"/>
        public OrderStoredCredentialRequest StoredCredential { get; set; }

        /// <summary>
        /// Subscription-specific data such as invoice ID, billing date, and sequence information.
        /// </summary>
        /// <seealso cref="OrderSubscriptionDataRequest"/>
        public OrderSubscriptionDataRequest SubscriptionData { get; set; }

    }

}
