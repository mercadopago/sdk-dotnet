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
        private OrderType? _type;
        private long? _id;

        #endregion

        #region Accessors
        /// <summary>
        /// Type of order
        /// </summary>
        public OrderType? Type { 
            get { return  _type; } 
            set { _type = value; } 
        }
        /// <summary>
        /// Id of the associated purchase order
        /// </summary>
        public long? Id { 
            get { return  _id; } 
            set { _id = value; } 
        } 
        #endregion
    }
}
