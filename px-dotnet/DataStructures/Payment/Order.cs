using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Order
    {
        /// <summary>
        /// Type of order
        /// </summary>
        public OrderType? Type { get; set; }

        /// <summary>
        /// Id of the associated purchase order
        /// </summary>
        public long? Id1 { get; set; }
    }
}
