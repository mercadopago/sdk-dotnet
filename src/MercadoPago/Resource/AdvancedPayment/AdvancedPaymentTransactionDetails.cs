namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Represents detailed transaction information for an <see cref="AdvancedPaymentSplitPayment"/>,
    /// including the total paid amount, external resource links, and financial institution data.
    /// </summary>
    public class AdvancedPaymentTransactionDetails
    {
        /// <summary>
        /// URL that identifies the transaction resource in the external payment processor.
        /// Typically used for ticket-based or redirect-based payment methods.
        /// </summary>
        public string ExternalResourceUrl { get; set; }

        /// <summary>
        /// Total amount paid by the buyer, including taxes, shipping, and any additional fees.
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// Identifier of the external financial institution that processed the payment
        /// (e.g., a bank name or code for bank transfer payments).
        /// </summary>
        public string FinancialInstitution { get; set; }
    }
}
