using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Identification
    {
        /// <summary>
        /// Identification type
        /// </summary>
        [StringLength(256)]
        public string Type { get; set; }

        /// <summary>
        /// Identification number
        /// </summary>
        [StringLength(256)]
        public string Number { get; set; }
    }
}
