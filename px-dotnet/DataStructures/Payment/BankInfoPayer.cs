namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Payer bank info
    /// </summary>
    public class BankInfoPayer
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

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
