using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Shipment
    {
        #region Properties 
        private ReceiverAddress _receiver_address; 
        #endregion

        #region Accessors
        /// <summary>
        /// Buyer's address
        /// </summary>
        public ReceiverAddress ReceiverAddress
        {
            get { return _receiver_address; }
            set { _receiver_address = value; }
        } 
        #endregion
    }
}
