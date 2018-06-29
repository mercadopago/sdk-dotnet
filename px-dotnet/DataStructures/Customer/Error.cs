using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Error
    {
        public string Code { get; private set; }

        public string Description { get; private set; }

        public string Field { get; private set; }
    }
}
