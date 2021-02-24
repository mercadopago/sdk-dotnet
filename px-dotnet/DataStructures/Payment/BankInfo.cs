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
        /// Is same bank account owner
        /// </summary>
        public string IsSameBankAccountOwner { get; set; }
    }
}
