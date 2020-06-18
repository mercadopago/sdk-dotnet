using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Shipment
    {
        #region Properties
        private bool _local_pickup;
        private ReceiverAddress? _receiver_address;
        private bool _express_shipment;
        #endregion

        #region Accessors
        /// <summary>
        /// Local pickup
        /// </summary>
        public bool Local_pickup
        {
            get { return _local_pickup; }
            set { _local_pickup = value; }
        }
        /// <summary>
        /// Buyer's address
        /// </summary>
        public ReceiverAddress? ReceiverAddress
        {
            get { return _receiver_address; }
            set { _receiver_address = value; }
        }
        /// <summary>
        /// Express Shipment
        /// </summary>
        public bool Express_shipment
        {
            get { return _express_shipment; }
            set { _express_shipment = value; }
        }
        #endregion
    }
}