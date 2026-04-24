// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents the shipping details for a payment order, including the delivery address.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    /// <seealso cref="OrderAddressRequest"/>
    public class OrderShipmentRequest
    {
        /// <summary>
        /// Delivery address where the order items will be shipped.
        /// </summary>
        /// <seealso cref="OrderAddressRequest"/>
        public OrderAddressRequest Address { get; set; }
    }
}
