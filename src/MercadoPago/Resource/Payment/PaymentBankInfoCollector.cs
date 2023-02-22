using System.Numerics;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Collector's bank info.
    /// </summary>
    public class PaymentBankInfoCollector
    {
        /// <summary>
        /// Account ID.
        /// </summary>
        public BigInteger? AccountId { get; set; }

        /// <summary>
        /// Account long name.
        /// </summary>
        public string LongName { get; set; }
    }
}
