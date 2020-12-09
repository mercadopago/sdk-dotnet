namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Transaction details.
    /// </summary>
    public class AdvancedPaymentTransactionDetails
    {
        /// <summary>
        /// Identifies the resource in the payment processor.
        /// </summary>
        public string ExternalResourceUrl { get; set; }

        /// <summary>
        /// Total amount paid by the buyer (includes fees).
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// External financial institution identifier.
        /// </summary>
        public string FinancialInstitution { get; set; }
    }
}
