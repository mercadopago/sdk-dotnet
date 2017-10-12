using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public class DefaultAddress
    {
        #region Properties

        private string _id;
        private string _zip_code;
        private string _street_name;
        private string _street_number;

        #endregion

        #region Accessors

        public string id
        {
            get { return _id; }
        }

        public string zip_code
        {
            get { return _zip_code; }
            set { _zip_code = value; }
        }

        public string street_name
        {
            get { return _street_name; }
            set { _street_name = value; }
        }

        public string street_number
        {
            get { return _street_number; }
            set { _street_number = value; }
        }

        #endregion
    }
}
