using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Address
    {
        /// <summary>
        /// Address ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number
        /// </summary>
        public string StreetNumber { get; set; }
    }
}
