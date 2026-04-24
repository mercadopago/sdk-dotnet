namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Shipping information for a payment, containing the delivery
    /// destination address. Part of <see cref="PaymentAdditionalInfo"/>.
    /// </summary>
    public class PaymentShipments
    {
        /// <summary>
        /// Address where the purchased items will be delivered,
        /// including street, city, state, and apartment details.
        /// </summary>
        /// <seealso cref="PaymentReceiverAddress"/>
        public PaymentReceiverAddress ReceiverAddress { get; set; }
    }
}
