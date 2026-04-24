namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Request payload for creating a refund on a specific disbursement of an advanced payment.
    /// Used internally by <see cref="AdvancedPaymentRefundClient"/>.
    /// </summary>
    public class AdvancedPaymentRefundCreateRequest
    {
        /// <summary>
        /// Amount to refund in the payment currency. Pass <c>null</c> to refund the full
        /// disbursement amount, or specify a value for a partial refund.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
