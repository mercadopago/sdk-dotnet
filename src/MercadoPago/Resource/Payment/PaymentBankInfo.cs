namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Bank account information associated with a payment transaction,
    /// covering both the payer's and collector's bank details.
    /// Used primarily for bank transfer and Pix payments.
    /// </summary>
    public class PaymentBankInfo
    {
        /// <summary>
        /// Bank account information of the payer (buyer) involved in this transaction.
        /// </summary>
        /// <seealso cref="PaymentBankInfoPayer"/>
        public PaymentBankInfoPayer Payer { get; set; }

        /// <summary>
        /// Bank account information of the collector (seller) receiving the funds.
        /// </summary>
        /// <seealso cref="PaymentBankInfoCollector"/>
        public PaymentBankInfoCollector Collector { get; set; }

        /// <summary>
        /// Indicates whether the payer and the collector share the same bank
        /// account ownership. Possible values: "yes", "no", or <c>null</c> if unknown.
        /// </summary>
        public string IsSameBankAccountOwner { get; set; }
    }
}
