namespace MercadoPago.Client.AdvancedPayment
{
    using System;

    /// <summary>
    /// Request payload used to update the money release date for disbursements of an advanced payment.
    /// Used internally by the <see cref="AdvancedPaymentClient"/> UpdateReleaseDate and
    /// UpdateReleaseDateAsync methods.
    /// </summary>
    public class AdvancedPaymentUpdateReleaseDateRequest
    {
        /// <summary>
        /// New date when the disbursed funds will be released to the seller.
        /// Must be a future date.
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }
    }
}
