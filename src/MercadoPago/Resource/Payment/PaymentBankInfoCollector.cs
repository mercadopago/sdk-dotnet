using System.Numerics;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Bank account information for the collector (seller) receiving
    /// funds in a bank transfer or Pix payment.
    /// </summary>
    public class PaymentBankInfoCollector
    {
        /// <summary>
        /// Unique identifier of the collector's bank account.
        /// </summary>
        public BigInteger? AccountId { get; set; }

        /// <summary>
        /// Full descriptive name of the collector's bank account,
        /// typically including the account holder's name and bank.
        /// </summary>
        public string LongName { get; set; }
    }
}
