using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Address
    {
        #region Properties

        [StringLength(256)]
        private string streetName;
        [StringLength(256)]
        private string zipCode;

        #endregion

        #region Accessors

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
       
        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        #endregion
    }
}
