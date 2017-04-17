using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class AdditionalInfoPayer
    {
        #region Properties

        private string firstName;
        private string lastName;
        private Phone phone;
        private Address address;
        private DateTime registrationDate;

        #endregion

        #region Accessors

        public string FirstName
        {            
            set { firstName = value; }
        }
       
        public string LastName
        {            
            set { lastName = value; }
        }
       
        public Phone Phone
        {            
            set { phone = value; }
        }
       
        public Address Address
        {            
            set { address = value; }
        }
       
        public DateTime RegistrationDate
        {            
            set { registrationDate = value; }
        }

        #endregion
    }
}
