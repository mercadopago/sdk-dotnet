using System.Numerics;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Bank account information for the payer (buyer) in a bank transfer
    /// or Pix payment transaction.
    /// </summary>
    public class PaymentBankInfoPayer
    {
        /// <summary>
        /// Email address associated with the payer's bank account.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Unique identifier of the payer's bank account.
        /// </summary>
        public BigInteger? AccountId { get; set; }

        /// <summary>
        /// Full descriptive name of the payer's bank account,
        /// typically including the account holder's name and bank.
        /// </summary>
        public string LongName { get; set; }
    }
}
