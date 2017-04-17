using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer.Card
{
    public class SecurityCode
    {
        #region Properties

        private int length;
        private string cardLocation;

        #endregion

        #region Accessors

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public string CardLocation
        {
            get { return cardLocation; }
            set { cardLocation = value; }
        }

        #endregion

    }
}
