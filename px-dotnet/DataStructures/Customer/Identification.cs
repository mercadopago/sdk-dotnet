using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Identification
    {
        #region Properties 
        private string _type;
        private string _number; 
        #endregion

        #region Accessors
        /// <summary>
        /// Identification's type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Identification's number
        /// </summary>
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        } 
        #endregion      
    }
}
