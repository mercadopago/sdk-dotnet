namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Expanded data information.
    /// </summary>
    public class PaymentExpandedData
    {
        /// <summary>
        /// Gateway information.
        /// </summary>
        public PaymentGatewayData Gateway { get; set; }
    }

    /// <summary>
    /// Gateway data information.
    /// </summary>
    public class PaymentGatewayData
    {
        /// <summary>
        /// Reference information.
        /// </summary>
        public NetworkTransactionData Reference { get; set; }
    }
}