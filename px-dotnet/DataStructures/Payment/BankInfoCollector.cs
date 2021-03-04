namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Collector bank info
    /// </summary>
    public class BankInfoCollector
    {
        /// <summary>
        /// Account ID
        /// </summary>
        public long? AccountId { get; set; }

        /// <summary>
        /// Long Name
        /// </summary>
        public string LongName { get; set; }
    }
}
