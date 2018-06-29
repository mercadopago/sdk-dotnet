using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct ReceiverAddress
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
        public string Zip_code { get; set; }

        /// <summary>
        /// Floor
        /// </summary>
        [StringLength(256)]
        public string Floor { get; set; }

        /// <summary>
        /// Apartment
        /// </summary>
        [StringLength(256)]
        public string Apartment { get; set; }
    }
}
