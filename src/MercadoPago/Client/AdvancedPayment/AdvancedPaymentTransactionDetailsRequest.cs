namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Transaction details.
    /// </summary>
    public class AdvancedPaymentTransactionDetailsRequest
    {
        /// <summary>
        /// Identifies the resource in the payment processor.
        /// </summary>
        public string ExternalResourceUrl { get; set; }
    }
}
