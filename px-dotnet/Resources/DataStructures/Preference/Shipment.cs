using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class Shipment
    {
        public enum ShipmentMode { Custom, Me2, NotSpecified }
        private ShipmentMode Mode { get; set; }
        private bool LocalPickUp { get; set; }
        private string Dimensions { get; set; }
        private int DefaultShippingMethod { get; set; }
        private List<int> Freemethods { get; set; }
        private float Cost { get; set; }
        private bool FreeShipping { get; set; }
        private ReceiverAddress ReceiverAddress { get; set; }
    }
}
