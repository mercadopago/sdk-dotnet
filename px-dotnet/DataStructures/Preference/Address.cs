using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Address
    {
        /// <summary>
        /// Street name
        /// </summary>
        [StringLength(256)]
        public string StreetName { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        public int StreetNumber { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [StringLength(256)]
        public string ZipCode { get; set; }
    }
}
