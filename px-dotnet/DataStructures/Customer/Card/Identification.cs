using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct Identification
    {
        /// <summary>
        /// Identification number
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Identification subtype
        /// </summary>
        public string Subtype { get; set; }

        /// <summary>
        /// Identification type
        /// </summary>
        public string Type { get; set; }
    }
}
