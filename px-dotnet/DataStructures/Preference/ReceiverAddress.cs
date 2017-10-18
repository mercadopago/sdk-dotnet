using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct ReceiverAddress
    {
        #region Properties

        [StringLength(256)]
        private string zipCode;

        [StringLength(256)]
        private string streetName;

        private int streetNumber;

        [StringLength(256)]
        private string floor;

        [StringLength(256)]
        private string apartment;

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
            get { return this.streetNumber; }
            set { this.streetNumber = value; }
        }

        public string Floor
        {
            get { return this.floor; }
            set { this.floor = value; }
        }

        public string Apartment
        { 
            get { return this.apartment; }
            set { this.apartment = value; }
        }

        #endregion
    }
}
