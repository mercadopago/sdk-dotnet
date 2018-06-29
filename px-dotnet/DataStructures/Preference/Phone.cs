using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Phone
    {
        /// <summary>
        /// Phone area code
        /// </summary>
        [StringLength(256)]
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [StringLength(256)]
        public string Number { get; set; }
    }
}
