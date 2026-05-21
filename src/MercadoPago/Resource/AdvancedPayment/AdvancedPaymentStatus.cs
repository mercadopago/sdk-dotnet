namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Defines the possible status values for an <see cref="AdvancedPayment"/>.
    /// Use these constants to compare against the <see cref="AdvancedPayment.Status"/> property.
    /// </summary>
    public class AdvancedPaymentStatus
    {
        /// <summary>
        /// The advanced payment has been approved and the funds have been accredited.
        /// </summary>
        public const string Approved = "approved";

        /// <summary>
        /// The payer has not yet completed the payment process. The payment is awaiting action.
        /// </summary>
        public const string Pending = "pending";

        /// <summary>
        /// The payment has been authorized but not yet captured. A capture call is required to complete the charge.
        /// </summary>
        public const string Authorized = "authorized";

        /// <summary>
        /// The advanced payment was rejected by the payment processor. The payer may retry with a different payment method.
        /// </summary>
        public const string Rejected = "rejected";

        /// <summary>
        /// The advanced payment was cancelled by one of the parties or because
        /// the time allowed for payment has expired.
        /// </summary>
        public const string Cancelled = "cancelled";

        /// <summary>
        /// The advanced payment was fully refunded to the payer.
        /// </summary>
        public const string Refunded = "refunded";

        /// <summary>
        /// A partial amount of the advanced payment was refunded to the payer.
        /// </summary>
        public const string PartiallyRefunded = "partially_refunded";

        /// <summary>
        /// A chargeback was initiated on the buyer’s credit card by the card issuer.
        /// </summary>
        public const string ChargedBack = "charged_back";
    }
}
