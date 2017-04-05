using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class BackUrl
    {
        [StringLength(600)]
        private string Success { get; set; }

        [StringLength(600)]
        private string Pending { get; set; }

        [StringLength(600)]
        private string Failure { get; set; }
    }
}
