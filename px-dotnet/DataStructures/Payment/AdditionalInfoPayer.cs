using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct AdditionalInfoPayer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Phone Phone { get; set; }

        public Address Address { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
