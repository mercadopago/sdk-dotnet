using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct AdditionalInfo
    {
        #region Properties

        private List<Item> items;
        private AdditionalInfoPayer additionalInfoPayer;
        private Shipment shipment;

        #endregion

        #region Accessors

        public List<Item> Items
        {            
            get { return this.items; } // Must be removed after testing approval.
            set { items = value; }
        }

        public AdditionalInfo AppendItem(Item item)
        {
            if (items == null)
            {
                items = new List<Item>();
            }
            items.Add(item);
            return this;
        }
       
        public AdditionalInfoPayer AdditionalInfoPayer
        {            
            set { additionalInfoPayer = value; }
        }
       
        public Shipment Shipment
        {            
            set { shipment = value; }
        }

        #endregion
    }
}
