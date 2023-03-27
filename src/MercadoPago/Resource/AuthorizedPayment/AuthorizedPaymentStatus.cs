namespace MercadoPago.Resource.AuthorizedPayment
{
    using System;

    /// <summary>
    /// Payment status related to the invoice.
    /// </summary>
    public class AuthorizedPaymentStatus
    {
        /// <summary>
        /// Unique payment identifier.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payment status.
        /// <list type="bullet">
        ///   <item><c>pending</c>: The user has not yet completed the payment process</item>
        ///   <item><c>approved</c>: The payment has been approved and accredited</item>
        ///   <item><c>authorized</c>: The payment has been authorized but not captured yet</item>
        ///   <item><c>in_process</c>: Payment is being reviewed</item>
        ///   <item><c>in_mediation</c>: Users have initiated a dispute</item>
        ///   <item><c>rejected</c>: Payment was rejected. The user may retry payment</item>
        ///   <item><c>cancelled</c>: Payment was cancelled by one of the parties or because time for payment has expired</item>
        ///   <item><c>refunded</c>: Payment was refunded to the user</item>
        ///   <item><c>charged_back</c>: Was made a chargeback in the buyer’s credit card</item>
        /// </list>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Payment status detail.
        /// </summary>
        public string StatusDetail { get; set; }
    }
}
