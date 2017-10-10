using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class DifferentialPricing
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
