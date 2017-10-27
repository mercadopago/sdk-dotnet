using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Order
    {
        #region Properties 

        private OrderType? type;
        private long? id;

        #endregion

        #region Accessors

        public OrderType? OrderType
        {
            get { return type; }
            set { type = value; }
        }

        

        public long? Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion
    }
}
