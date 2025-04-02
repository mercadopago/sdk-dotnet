using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Payment class.
    /// </summary>
    public class OrderPayment
    {
        /// <summary>
        /// Payment ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Reference ID.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Payment status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Payment status detail.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Attempt number.
        /// </summary>
        public int? AttemptNumber { get; set; }

        /// <summary>
        /// Attempts.
        /// </summary>
        public IList<OrderAttempt> Attempts { get; set; }

        /// <summary>
        /// Date of expiration.
        /// </summary>
        public string DateOfExpiration { get; set; }

        /// <summary>
        /// Expiration time.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Payment amount.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Paid amount.
        /// </summary>
        public string PaidAmount { get; set; }

        /// <summary>
        /// Payment Method information.
        /// </summary>
        public OrderPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Automatic Payments information.
        /// </summary>
        public OrderAutomaticPayments AutomaticPayments { get; set; }

        /// <summary>
        /// Stored Credential information.
        /// </summary>
        public OrderStoredCredential StoredCredential { get; set; }

        /// <summary>
        /// Subscription Data information.
        /// </summary>
        public OrderSubscriptionData SubscriptionData { get; set; }
    }
}
