using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Phone
    {
        #region Properties 
        private string _area_code;
        private string _number; 
        #endregion

        #region Accessors
        /// <summary>
        /// Phone's area code
        /// </summary>
        public string AreaCode
        {
            get { return _area_code; }
            set { _area_code = value; }
        }
        /// <summary>
        /// Phone's number
        /// </summary>
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        } 
        #endregion
    }
}
