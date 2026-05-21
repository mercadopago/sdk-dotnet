namespace MercadoPago.Resource.AuthorizedPayment
{
    using System;

    /// <summary>
    /// Payment processing status associated with an
    /// <see cref="AuthorizedPayment"/> invoice. Contains the resulting payment
    /// identifier and its lifecycle status after a collection attempt.
    /// </summary>
    public class AuthorizedPaymentStatus
    {
        /// <summary>
        /// Unique identifier of the payment generated for this invoice.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Current lifecycle status of the payment.
        /// <list type="bullet">
        ///   <item><c>pending</c>: The user has not yet completed the payment process.</item>
        ///   <item><c>approved</c>: The payment has been approved and accredited.</item>
        ///   <item><c>authorized</c>: The payment has been authorized but not captured yet.</item>
        ///   <item><c>in_process</c>: Payment is being reviewed.</item>
        ///   <item><c>in_mediation</c>: Users have initiated a dispute.</item>
        ///   <item><c>rejected</c>: Payment was rejected. The user may retry payment.</item>
        ///   <item><c>cancelled</c>: Payment was cancelled by one of the parties or because time for payment has expired.</item>
        ///   <item><c>refunded</c>: Payment was refunded to the user.</item>
        ///   <item><c>charged_back</c>: A chargeback was initiated on the buyer’s credit card.</item>
        /// </list>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed reason for the current <see cref="Status"/> (e.g.
        /// <c>accredited</c>, <c>cc_rejected_insufficient_amount</c>).
        /// </summary>
        public string StatusDetail { get; set; }
    }
}
