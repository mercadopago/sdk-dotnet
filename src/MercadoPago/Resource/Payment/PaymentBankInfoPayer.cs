namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Payer's bank info.
    /// </summary>
    public class PaymentBankInfoPayer
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Account ID.
        /// </summary>
        public long? AccountId { get; set; }

        /// <summary>
        /// Account long name.
        /// </summary>
        public string LongName { get; set; }
    }
}
