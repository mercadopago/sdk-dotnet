namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Defines string constants for all possible <see cref="Payment.Status"/> values.
    /// Use these constants to compare against the <see cref="Payment.Status"/>
    /// property instead of hard-coding status strings.
    /// </summary>
    public static class PaymentStatus
    {
        /// <summary>
        /// The payment has been approved and the funds have been accredited
        /// to the collector’s account.
        /// </summary>
        public const string Approved = "approved";

        /// <summary>
        /// The payer has not yet completed the payment process.
        /// The payment is awaiting action (e.g., cash deposit or bank transfer).
        /// </summary>
        public const string Pending = "pending";

        /// <summary>
        /// The payment has been authorized by the card issuer but has not
        /// been captured yet. Requires a capture action to complete the payment.
        /// </summary>
        public const string Authorized = "authorized";

        /// <summary>
        /// The payment is being reviewed by MercadoPago’s fraud prevention
        /// system. The final status will be determined after review.
        /// </summary>
        public const string InProcess = "in_process";

        /// <summary>
        /// A dispute has been initiated by the buyer. The payment is under
        /// mediation and the outcome is pending resolution.
        /// </summary>
        public const string InMediation = "in_mediation";

        /// <summary>
        /// The payment was rejected by the payment processor or issuer.
        /// The payer may retry the payment with a different method or card.
        /// </summary>
        public const string Rejected = "rejected";

        /// <summary>
        /// The payment was cancelled by one of the parties (payer or collector)
        /// or automatically expired because the payment deadline was reached.
        /// </summary>
        public const string Cancelled = "cancelled";

        /// <summary>
        /// The payment was fully refunded to the payer.
        /// </summary>
        public const string Refunded = "refunded";

        /// <summary>
        /// A chargeback was initiated on the buyer’s credit card.
        /// The funds have been reversed to the buyer by the card issuer.
        /// </summary>
        public const string ChargedBack = "charged_back";
    }
}
