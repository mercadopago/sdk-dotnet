using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Preference
{
    public struct Tax {
        #region Properties
        private TaxType? _type;
        private float? _value;
        #endregion

        #region Accessors
        /// <summary>
        /// Tax type
        /// </summary>
        public TaxType? Type { 
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// Tax value
        /// </summary>
        public float? Value { 
            get { return _value; }
            set { _value = value; }
        }
        #endregion
    }
}