using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Phone
    {
        #region Properties

        private string area_code;
        private string number;

        #endregion

        #region Accessors

        public string AreaCode
        {
            get { return area_code; }
            set { area_code = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion
    }
}
