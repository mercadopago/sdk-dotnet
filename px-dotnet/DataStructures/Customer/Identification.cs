using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public class Identification
    {
        #region Properties

        private string _type;
        private string _number;

        #endregion

        #region Accessors

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion      
    }
}
