using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Identification
    {
        #region Properties

        private string type;
        private string number;

        #endregion

        #region Accessors

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion      
    }
}
