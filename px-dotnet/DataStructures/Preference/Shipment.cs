using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public class Shipment
    {
        #region Properties

        public enum ShipmentMode 
        { 
            Custom,
            Me2, 
            NotSpecified 
        }
        
        private ShipmentMode mode;
        private bool localPickUp;
        private string dimensions;
        private int defaultShippingMethod;
        private List<int> freeMethods;
        private decimal cost;
        private bool freeShipping;
        private ReceiverAddress receiverAddress;

        #endregion

        #region Accessors

        public ShipmentMode Mode
        {
            get { return this.mode; }
            set { this.mode = value; }
        }

        public bool LocalPickUp
        {
            get { return this.localPickUp; }
            set { this.localPickUp = value; }
        }

        public string Dimensions
        {
            get { return this.dimensions; }
            set { this.dimensions = value; }
        }

        public int DefaultShippingMethod
        {
            get { return this.defaultShippingMethod; }
            set { this.defaultShippingMethod = value; }
        }

        public List<int> FreeMethods
        {
            get { return this.freeMethods; }
            set { this.freeMethods = value; }
        }

        public decimal Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        public bool FreeShipping
        {
            get { return this.freeShipping; }
            set { this.freeShipping = value; }
        }

        public ReceiverAddress ReceiverAddress
        {
            get { return this.receiverAddress; }
            set { this.receiverAddress = value; }
        }
        #endregion

    }
}
