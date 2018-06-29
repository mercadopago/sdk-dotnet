using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct CardHolder
    {
        /// <summary>
        /// Cardholder Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the cardholder
        /// </summary>
        public Identification? Identification { get; set; }
    }
}
