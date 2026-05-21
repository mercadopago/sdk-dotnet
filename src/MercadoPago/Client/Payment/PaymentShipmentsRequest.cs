namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Shipping information for a payment, included in <see cref="PaymentAdditionalInfoRequest"/>.
    /// Describes delivery details such as the receiver's address and shipment options.
    /// </summary>
    public class PaymentShipmentsRequest
    {
        /// <summary>
        /// Receiver's delivery address including street, city, state, and apartment details.
        /// </summary>
        /// <seealso cref="PaymentReceiverAddressRequest"/>
        public PaymentReceiverAddressRequest ReceiverAddress { get; set; }

        /// <summary>
        /// <c>true</c> if the buyer will pick up the product at the store;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// <c>true</c> if the shipment uses express delivery;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? ExpressShipment { get; set; }
    }
}
