using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class PayerPhone
    {
        #region Properties

        private string _area_code;
        private string _extension;
        private string _number;                

        #endregion

        #region Accessors

        public string AreaCode
        {
            get { return _area_code; }
            private set { _area_code = value; }
        }

        public string Number
        {
            get { return _number; }
            private set { _number = value; }
        }

        public string Extension
        {
            get { return _extension; }
            private set { _extension = value; }
        }

        #endregion
    }
}
