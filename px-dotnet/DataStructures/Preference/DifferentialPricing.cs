using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct DifferentialPricing
    {
        #region Properties

        private int id;

        #endregion

        #region Accessors

        public int ID
        {
            get{ return this.ID; }
            set{ this.id = value; }
        }
        
        #endregion
    }
}
