using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Forward data for payment facilitator flows within a <see cref="PaymentCreateRequest"/>.
    /// Contains sub-merchant identification and network transaction data used when
    /// a payment facilitator processes payments on behalf of sub-merchants.
    /// </summary>
    public class PaymentForwardDataRequest
    {
        /// <summary>
        /// Sub-merchant details for payment facilitator integrations.
        /// Identifies the actual seller when a facilitator processes the payment.
        /// </summary>
        /// <seealso cref="SubMerchant"/>
        public SubMerchant SubMerchant { get; set; }

        /// <summary>
        /// Network-level transaction data for card network processing.
        /// </summary>
        /// <seealso cref="Common.NetworkTransactionData"/>
        public NetworkTransactionData NetworkTransactionData { get; set; }
    }
}
