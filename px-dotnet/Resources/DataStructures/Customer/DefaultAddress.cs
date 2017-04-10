using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class DefaultAddress
    {
        #region Properties

        private string id;
        private string zipCode;
        private string streetName;
        private string streetNumber;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
        }

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

        public string StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }

        #endregion
    }
}
