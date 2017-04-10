using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Phone
    {
        #region Properties

        private string areaCode;
        private string number;

        #endregion

        #region Accessors

        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion       
    }
}
