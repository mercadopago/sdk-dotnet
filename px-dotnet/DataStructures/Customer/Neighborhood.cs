using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Neighborhood
    {
        #region Properties

        private string id;
        private string name;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        #endregion
    }
}
