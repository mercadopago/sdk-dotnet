using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Verification
    {
        public List<Shipment> Shipments { get; private set; }
    }
}
