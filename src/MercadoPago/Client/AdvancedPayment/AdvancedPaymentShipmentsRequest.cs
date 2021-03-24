namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Shipping Information
    /// </summary>
    public class AdvancedPaymentShipmentsRequest
    {
        /// <summary>
        /// Receiver Address.
        /// </summary>
        public AdvancedPaymentReceiverAddressRequest ReceiverAddress { get; set; }
    }
}
