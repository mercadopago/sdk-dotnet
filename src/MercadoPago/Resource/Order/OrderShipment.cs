// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the shipping details for an <see cref="Order"/>, containing the delivery address
    /// for physical goods.
    /// </summary>
    public class OrderShipment
    {
        /// <summary>
        /// Shipping mode (e.g., "custom" or "not_specified").
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Indicates whether the payer can pick up the product in person.
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// Shipping cost expressed in the order currency.
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// Indicates whether shipping is free for the payer.
        /// </summary>
        public bool? FreeShipping { get; set; }

        /// <summary>
        /// Free shipping methods available to the payer.
        /// </summary>
        /// <seealso cref="OrderFreeMethod"/>
        public IList<OrderFreeMethod> FreeMethods { get; set; }

        /// <summary>
        /// Delivery address for this shipment. See <see cref="OrderShipmentAddress"/> for street, city, and postal code fields.
        /// </summary>
        public OrderShipmentAddress Address { get; set; }
    }
}
