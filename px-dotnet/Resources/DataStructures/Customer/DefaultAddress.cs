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
        private string zip_code;
        private string street_name;
        private string street_number;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
        }

        public string ZipCode
        {
            get { return zip_code; }
            set { zip_code = value; }
        }

        public string StreetName
        {
            get { return street_name; }
            set { street_name = value; }
        }

        public string StreetNumber
        {
            get { return street_number; }
            set { street_number = value; }
        }

        #endregion
    }
}
