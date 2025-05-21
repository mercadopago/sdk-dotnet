using MercadoPago.Client.Common;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Forward data information.
    /// </summary>
    public class PaymentForwardData
    {
        /// <summary>
        /// Network transaction data.
        /// </summary>
        public NetworkTransactionData NetworkTransactionData { get; set; }
    }
}
