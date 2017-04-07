using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class CardHolder
    {
        #region Properties

        private string name;        
        private Identification identification;
       
        #endregion

        #region Accessors

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Identification Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        #endregion
    }
}
