using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct Issuer
    {
        /// <summary>
        /// Issuer Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Issuer name
        /// </summary>
        public string Name { get; set; }
    }
}
