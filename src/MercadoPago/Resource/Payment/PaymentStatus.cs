namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Status of payments.
    /// </summary>
    public static class PaymentStatus
    {
        /// <summary>
        /// The payment has been approved and accredited.
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
        /// Payment is being reviewed.
        /// </summary>
        public const string InProcess = "in_process";

        /// <summary>
        /// Users have initiated a dispute.
        /// </summary>
        public const string InMediation = "in_mediation";

        /// <summary>
        /// Payment was rejected. The user may retry payment.
        /// </summary>
        public const string Rejected = "rejected";

        /// <summary>
        /// Payment was cancelled by one of the parties or because
        /// time for payment has expired.
        /// </summary>
        public const string Cancelled = "cancelled";

        /// <summary>
        /// Payment was refunded to the user.
        /// </summary>
        public const string Refunded = "refunded";

        /// <summary>
        /// Was made a chargeback in the buyer’s credit card.
        /// </summary>
        public const string ChargedBack = "charged_back";
    }
}
