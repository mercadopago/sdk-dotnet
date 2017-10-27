using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Identification
    {
        #region Properties 
        [StringLength(256)]
        private string _type;
        [StringLength(256)]
        private string _number; 
        #endregion

        #region Accessors 
        /// <summary>
        /// Identification type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        } 
        /// <summary>
        /// Identification number
        /// </summary>
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        } 
        #endregion
    }
}
