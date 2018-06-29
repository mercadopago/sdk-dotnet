using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoPago.DataStructures.Payment
{ 
    public struct AdditionalInfoAddress
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
