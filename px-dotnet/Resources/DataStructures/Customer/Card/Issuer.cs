using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer.Card
{
    public class Issuer
    {
        #region Properties

        private string id;
        private string name;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion                
    }
}
