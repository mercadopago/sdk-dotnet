using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Shipment
    {
        #region Properties

        private ReceiverAddress receiverAddress;

        #endregion

        #region Accessors

        public ReceiverAddress ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }

        #endregion
    }
}
