namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Shipping Information
    /// </summary>
    public class PaymentShipmentsRequest
    {
        /// <summary>
        /// Receiver Address.
        /// </summary>
        public PaymentReceiverAddressRequest ReceiverAddress { get; set; }

        /// <summary>
        /// <c>true</c> if the product is picked up at the store, <c>false</c>
        /// if not.
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// <c>true</c> if the shipment is express, <c>false</c> if not.
        /// </summary>
        public bool? ExpressShipment { get; set; }
    }
}
