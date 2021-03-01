namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Bank info
    /// </summary>
    public class BankInfo
    {
        /// <summary>
        /// Payer info
        /// </summary>
        public BankInfoPayer Payer { get; set; }

        /// <summary>
        /// Collector info
        /// </summary>
        public BankInfoCollector Collector { get; set; }

        /// <summary>
        /// <c>true</c> if is same bank account owner, otherwise <c>false</c>
        /// </summary>
        public bool? IsSameBankAccountOwner { get; set; }
    }
}
