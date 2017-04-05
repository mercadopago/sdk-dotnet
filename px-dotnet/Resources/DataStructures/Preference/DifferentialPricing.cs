using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class DifferentialPricing
    {
        private int ID { get; set; }

        #region Methods
        public int Get() 
        {
            return this.ID;
        }

        public void Set(int id)
        {
            this.ID = id;
        }
        #endregion
    }
}
