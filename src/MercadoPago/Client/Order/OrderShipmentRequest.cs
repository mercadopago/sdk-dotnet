// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the shipping details for a payment order, including the delivery address.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    /// <seealso cref="OrderAddressRequest"/>
    public class OrderShipmentRequest
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
        /// Shipping cost expressed as a decimal string.
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// Indicates whether shipping is free for the payer.
        /// </summary>
        public bool? FreeShipping { get; set; }

        /// <summary>
        /// Free shipping methods available to the payer.
        /// </summary>
        /// <seealso cref="OrderFreeMethodRequest"/>
        public IList<OrderFreeMethodRequest> FreeMethods { get; set; }

        /// <summary>
        /// Delivery address where the order items will be shipped.
        /// </summary>
        /// <seealso cref="OrderAddressRequest"/>
        public OrderAddressRequest Address { get; set; }
    }
}
