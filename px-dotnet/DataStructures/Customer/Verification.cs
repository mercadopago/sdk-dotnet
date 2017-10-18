using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Verification
    {
        #region Properties

        private List<Shipment> shipments;

        #endregion

        #region Accessors

        public List<Shipment> Shipments
        {
            get { return shipments; }
        }

        #endregion
    }
}
