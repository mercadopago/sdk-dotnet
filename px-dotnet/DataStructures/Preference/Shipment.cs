using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Preference
{
    public struct Shipment
    {
        /// <summary>
        /// Shipment mode
        /// </summary>
        public ShipmentMode? Mode { get; set; }

        /// <summary>
        /// The payer have the option to pick up the shipment in your store (mode:me2 only)
        /// </summary>
        public bool LocalPickUp { get; set; }

        /// <summary>
        /// Dimensions of the shipment in cm x cm x cm, gr (mode:me2 only)
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// Select default shipping method in checkout (mode:me2 only)
        /// </summary>
        public int DefaultShippingMethod { get; set; }

        /// <summary>
        /// Offer a shipping method as free shipping (mode:me2 only)
        /// </summary>
        public List<int> FreeMethods { get; set; }

        /// <summary>
        /// Shipment cost (mode:custom only)
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Free shipping for mode:custom
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        public ReceiverAddress? ReceiverAddress { get; set; }
    }
}
