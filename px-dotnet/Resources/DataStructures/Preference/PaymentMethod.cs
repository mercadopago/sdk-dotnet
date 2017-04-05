using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class PaymentMethod
    {
        private ExcludedPaymentMethod ExcludedPaymentMethod { get; set; }
        private ExcludedPaymentType ExcludedPaymentType { get; set; }
        
        [StringLength(256)]
        private string DefaultPaymentMethodId { get; set; }

        private int Installment { get; set; }

        private int DefaultInstallment { get; set; }
    }
}
