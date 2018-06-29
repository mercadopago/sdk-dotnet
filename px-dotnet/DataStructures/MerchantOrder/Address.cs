using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct Address
    {
        [StringLength(256)]
        public string ZipCode { get; set; }

        [StringLength(256)]
        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        [StringLength(256)]
        public string Floor { get; set; }

        [StringLength(256)]
        public string Apartment { get; set; }
    }
}
