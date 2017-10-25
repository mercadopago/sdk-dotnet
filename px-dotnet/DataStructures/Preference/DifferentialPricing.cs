using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct DifferentialPricing
    {
        #region Properties 
        private int? _id; 
        #endregion

        #region Accessors
        /// <summary>
        /// Differential pricing ID
        /// </summary>
        public int? Id
        {
            get{ return this._id; }
            set{ this._id = value; }
        } 
        #endregion
    }
}
