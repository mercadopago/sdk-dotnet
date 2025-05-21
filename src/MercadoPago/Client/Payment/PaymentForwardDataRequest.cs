using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// FowardData information
    /// </summary>
    public class PaymentForwardDataRequest
    {
        /// <summary>
        /// Payer's personal identification.
        /// </summary>
        public SubMerchant SubMerchant { get; set; }

        /// <summary>
        /// Network transaction data.
        /// </summary>
        public NetworkTransactionData NetworkTransactionData { get; set; }
    }
}
