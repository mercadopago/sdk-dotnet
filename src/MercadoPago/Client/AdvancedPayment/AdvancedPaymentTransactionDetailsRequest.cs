namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Additional transaction metadata for a split payment within an advanced payment.
    /// </summary>
    /// <see cref="AdvancedPaymentSplitPaymentRequest"/>
    public class AdvancedPaymentTransactionDetailsRequest
    {
        /// <summary>
        /// URL that identifies the resource in the external payment processor's system.
        /// </summary>
        public string ExternalResourceUrl { get; set; }
    }
}
