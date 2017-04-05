using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class Address
    {
        #region Properties

        [StringLength(256)]
        private string zipCode = null;

        [StringLength(256)]
        private string streetName = null;

        private int? streetNumber = null;

        #endregion

        #region Accessors

        public string ZipCode 
        {
            get { return this.zipCode; }
            set { this.zipCode = value; }
        }

        public string StreetName 
        {
            get { return this.streetName; }
            set { this.streetName = value; }
        }

        public int StreetNumber 
        {
            get { return this.streetNumber.Value; }
            set { this.streetNumber = value; }
        }

        #endregion
    }
}
