using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Identification
    {
        /// <summary>
        /// Identification's type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification's number
        /// </summary>
        public string Number { get; set; }
    }
}
