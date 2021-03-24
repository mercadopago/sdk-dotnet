namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Bank info of payment's transaction.
    /// </summary>
    public class PaymentBankInfo
    {
        /// <summary>
        /// Payer info.
        /// </summary>
        public PaymentBankInfoPayer Payer { get; set; }

        /// <summary>
        /// Collector info.
        /// </summary>
        public PaymentBankInfoCollector Collector { get; set; }

        /// <summary>
        /// Is same bank account owner.
        /// </summary>
        public string IsSameBankAccountOwner { get; set; }
    }
}
