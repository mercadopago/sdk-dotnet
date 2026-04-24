namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Expanded payment data containing additional gateway-level details
    /// returned when the payment is processed in gateway mode.
    /// </summary>
    public class PaymentExpandedData
    {
        /// <summary>
        /// Gateway-specific data including network transaction references
        /// used for recurring and subsequent transactions.
        /// </summary>
        /// <seealso cref="PaymentGatewayData"/>
        public PaymentGatewayData Gateway { get; set; }
    }

    /// <summary>
    /// Gateway-level data containing network transaction references
    /// for payments processed in gateway mode.
    /// </summary>
    public class PaymentGatewayData
    {
        /// <summary>
        /// Network transaction reference data from the payment processor,
        /// typically used for recurring or merchant-initiated transactions.
        /// </summary>
        public NetworkTransactionData Reference { get; set; }
    }
}