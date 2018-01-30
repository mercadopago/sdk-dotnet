using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct CardHolder
    {
        #region Properties 
        private string _name;        
        private Identification? _identification;    
        #endregion

        #region Accessors
        /// <summary>
        /// Cardholder Name
        /// </summary>
        public string Name
        {
            get { return  _name; } 
            set { _name = value; }
        }
        /// <summary>
        /// ID of the cardholder
        /// </summary>
        public Identification? Identification
        {
            get { return  _identification; } 
            set { _identification = value; }
        }

        #endregion
    }
}
