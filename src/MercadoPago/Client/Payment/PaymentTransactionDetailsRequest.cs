namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Transaction details.
    /// </summary>
    public class PaymentTransactionDetailsRequest
    {
        /// <summary>
        /// External financial institution identifier
        /// </summary>
        public string FinancialInstitution { get; set; }
    }
}
