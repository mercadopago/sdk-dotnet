namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Represents shipping information for an <see cref="AdvancedPayment"/>,
    /// including the delivery destination address.
    /// </summary>
    public class AdvancedPaymentShipments
    {
        /// <summary>
        /// Address where the purchased items will be delivered.
        /// </summary>
        public AdvancedPaymentReceiverAddress ReceiverAddress { get; set; }
    }
}
