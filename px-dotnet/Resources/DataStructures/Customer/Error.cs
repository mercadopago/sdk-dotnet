using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Error
    {
        #region Properties

        private string code;
        private string description;
        private string field;                

        #endregion

        #region Accessors

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        #endregion
    }
}
