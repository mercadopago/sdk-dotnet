using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public class Phone
    {
        #region Properties

        private string _area_code;
        private string _number;

        #endregion

        #region Accessors

        public string area_code
        {
            get { return _area_code; }
            set { _area_code = value; }
        }

        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion
    }
}
