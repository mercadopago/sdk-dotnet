using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Shipment
    { 

        #region Accessors
        /// <summary>
        /// Local pickup
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// Buyer's address
        /// </summary>
        public ReceiverAddress? ReceiverAddress { get; set; }

        /// <summary>
        /// Express Shipment
        /// </summary>
        public bool? ExpressShipment { get; set; }
        #endregion
    }
}
