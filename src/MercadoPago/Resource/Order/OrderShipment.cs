// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the shipping details for an <see cref="Order"/>, containing the delivery address
    /// for physical goods.
    /// </summary>
    public class OrderShipment
    {
        /// <summary>
        /// Delivery address for this shipment. See <see cref="OrderShipmentAddress"/> for street, city, and postal code fields.
        /// </summary>
        public OrderShipmentAddress Address { get; set; }
    }
}
