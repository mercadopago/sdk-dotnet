using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class ExcludedPaymentType
    {
        [StringLength(256)]
        private string ID { get; set; }
    }
}
