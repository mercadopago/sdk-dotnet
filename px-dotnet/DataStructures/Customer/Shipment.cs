using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Shipment
    {
        public bool Success { get; private set; }

        public List<Error> Errors { get; private set; }

        public string Name { get; private set; }
    }
}
