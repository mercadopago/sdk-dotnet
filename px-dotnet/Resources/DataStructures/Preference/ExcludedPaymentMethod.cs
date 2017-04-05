using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class ExcludedPaymentMethod
    {
        [StringLength(256)]
        private string ID { get; set; }
    }
}
