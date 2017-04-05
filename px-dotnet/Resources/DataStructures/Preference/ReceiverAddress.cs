using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class ReceiverAddress
    {
        [StringLength(256)]
        private string ZipCode { get; set; }
        
        [StringLength(256)]
        private string StreetName { get; set; }

        private int StreetNumber { get; set; }

        [StringLength(256)]
        private string Floor { get; set; }

        [StringLength(256)]
        private string Apartment { get; set; }
    }
}
