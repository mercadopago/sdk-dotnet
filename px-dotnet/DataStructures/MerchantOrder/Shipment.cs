using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct Shipment
    {
        public int ID { get; set; }

        public string ShipmentType { get; set; }

        public string ShipmentMode { get; set; }

        public string PickingType { get; set; }

        public string Status { get; set; }

        public string Substatus { get; set; }

        // TODO: Object ???
        public Object Item { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime DateFirstPrinted { get; set; }

        public string ServiceId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public Address Address { get; set; }
    }
}
