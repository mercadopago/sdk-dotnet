using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct Shipment
    {
        #region Properties

        private int id;
        private string shipmentType;
        private string shipmentMode;
        private string pickingType;
        private string status;
        private string substatus;
        private Object item;
        private DateTime dateCreated;
        private DateTime lastModified;
        private DateTime dateFirstPrinted;
        private string serviceId;
        private int senderId;
        private int receiverId;
        private Address address;

        #endregion

        #region Accessors

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string ShipmentType
        {
            get { return shipmentType; }
            set { shipmentType = value; }
        }

        public string ShipmentMode
        {
            get { return shipmentMode; }
            set { shipmentMode = value; }
        }

        public string PickingType
        {
            get { return pickingType; }
            set { pickingType = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Substatus
        {
            get { return substatus; }
            set { substatus = value; }
        }

        public Object Item
        {
            get { return item; }
            set { item = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }

        public DateTime DateFirstPrinted
        {
            get { return dateFirstPrinted; }
            set { dateFirstPrinted = value; }
        }

        public string ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public int SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public int ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        #endregion
    }
}
