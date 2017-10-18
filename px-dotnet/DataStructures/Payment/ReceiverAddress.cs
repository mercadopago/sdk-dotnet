using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct ReceiverAddress
    {
        #region Properties

        [StringLength(256)]
        private string streetName;
        [StringLength(256)]
        private string zipCode;
        [StringLength(256)]
        private string floor;
        [StringLength(256)]
        private string apartment;

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

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }
        
        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        #endregion
    }
}
