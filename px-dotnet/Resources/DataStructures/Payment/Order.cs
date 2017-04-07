using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Order
    {
        #region Properties

        public enum Type 
        {
            MercadoLibre,
            MercadoPago
        }

        private Type type;
        private long id;

        #endregion

        #region Accessors

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        #endregion
    }
}
