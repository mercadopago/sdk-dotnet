using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class PayerPhone
    {
        #region Properties

        private string areaCode;
        private string extension;
        private string number;                

        #endregion

        #region Accessors

        public string AreaCode
        {
            get { return areaCode; }            
        }

        public string Number
        {
            get { return number; }            
        }

        public string Extension
        {
            get { return extension; }            
        }

        #endregion
    }
}
