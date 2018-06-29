using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct CardHolder
    {
        /// <summary>
        /// Card holder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identification information
        /// </summary>
        public Identification Identification { get; set; }
    }
}
