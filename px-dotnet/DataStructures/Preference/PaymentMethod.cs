using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct PaymentMethod
    {
        /// <summary>
        /// Payment method ID
        /// </summary>
        [StringLength(256)]
        public string Id { get; set; }
    }
}
