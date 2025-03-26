// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payment class.
    /// </summary>
    public class OrderPaymentRequest : IdempotentRequest
    {
        /// <summary>
        /// Payment amount.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Expiration time.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Payment method information.
        /// </summary>
        public OrderPaymentMethodRequest PaymentMethod { get; set; }

        /// <summary>
        /// Automatic Paymments information.
        /// </summary>
        public OrderAutomaticPaymentRequest AutomaticPayments { get; set; }

        /// <summary>
        /// Stored Credential information.
        /// </summary>
        public OrderStoredCredentialRequest StoredCredential { get; set; }

        /// <summary>
        /// Subscription Data information.
        /// </summary>
        public OrderSubscriptionDataRequest SubscriptionData { get; set; }

    }

}
