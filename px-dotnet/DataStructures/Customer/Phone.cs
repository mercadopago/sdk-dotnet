using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Phone
    {
        /// <summary>
        /// Phone's area code
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone's number
        /// </summary>
        public string Number { get; set; }
    }
}
