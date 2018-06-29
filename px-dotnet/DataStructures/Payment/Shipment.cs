using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Shipment
    {
        /// <summary>
        /// Buyer's address
        /// </summary>
        public ReceiverAddress ReceiverAddress { get; set; }
    }
}
