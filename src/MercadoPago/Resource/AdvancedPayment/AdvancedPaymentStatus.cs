namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Advanced Payment Status.
    /// </summary>
    public class AdvancedPaymentStatus
    {
        /// <summary>
        /// The advanced payment has been approved and accredited.
        /// </summary>
        public const string Approved = "approved";

        /// <summary>
        /// The user has not yet completed the payment process.
        /// </summary>
        public const string Pending = "pending";

        /// <summary>
        /// The payment has been authorized but not captured yet.
        /// </summary>
        public const string Authorized = "authorized";

        /// <summary>
        /// Advanced payment was rejected. The user may retry payment.
        /// </summary>
        public const string Rejected = "rejected";

        /// <summary>
        /// Advanced ayment was cancelled by one of the parties or because
        /// time for payment has expired.
        /// </summary>
        public const string Cancelled = "cancelled";

        /// <summary>
        /// Advanced payment was refunded to the user.
        /// </summary>
        public const string Refunded = "refunded";

        /// <summary>
        /// Part of the advanced payment was returned to the user.
        /// </summary>
        public const string PartiallyRefunded = "partially_refunded";

        /// <summary>
        /// Was made a chargeback in the buyer’s credit card.
        /// </summary>
        public const string ChargedBack = "charged_back";
    }
}
