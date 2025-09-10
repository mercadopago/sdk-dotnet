// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Shipment class.
    /// </summary>
    public class OrderShipmentRequest
    {
        /// <summary>
        /// Shipment address information.
        /// </summary>
        public OrderAddressRequest Address { get; set; }
    }
}
