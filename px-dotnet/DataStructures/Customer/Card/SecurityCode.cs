using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct SecurityCode
    {
        /// <summary>
        /// Security code's length
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Security code's card location
        /// </summary>
        public string CardLocation { get; set; }
    }
}
