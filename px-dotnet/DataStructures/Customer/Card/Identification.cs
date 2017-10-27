using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct Identification
    {
        #region Properties

        private int number;
        private string subtype;
        private string type;
        
        #endregion

        #region Accessors

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Subtype
        {
            get { return subtype; }
            set { subtype = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        #endregion
    }
}
