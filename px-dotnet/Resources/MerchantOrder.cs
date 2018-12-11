using MercadoPago.DataStructures.MerchantOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    public class MerchantOrder : MPBase
    {
        #region Actions
        
        public MerchantOrder Load(string id) 
        {
            return Load(id, WITHOUT_CACHE);
        }

        [GETEndpoint("/merchant_orders/:id")]
        public MerchantOrder Load(string id, bool useCache)
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>(typeof(MerchantOrder), "Load", id, useCache);
        }
        
        [POSTEndpoint("/merchant_orders")]
        public MerchantOrder Save() 
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>("Save", WITHOUT_CACHE);
        }
        
        [PUTEndpoint("/merchant_orders/:id")]
        public MerchantOrder Update() 
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>("Update", WITHOUT_CACHE);
        }

        #endregion

        #region Properties

        private long? _id;
        private string _preference_id;
        private DateTime? _date_created;
        private DateTime? _last_update;
        private string _application_id;
        private string _status;
        private string _site_id;
        private Payer _payer;
        private Collector _collector;
        private long? _sponsor_id;
        private List<MerchantOrderPayment> _payments;
        private float? _paid_amount;
        private float? _refunded_amount;
        private float? _shipping_cost;
        private bool? _cancelled;
        private List<Item> _items;
        private List<Shipment> _shipments;
        [StringLength(500)]
        private string _notification_url;
        [StringLength(600)]
        private string _additionalInfo;
        [StringLength(256)]
        private string _external_reference;
        [StringLength(256)]
        private string _marketplace;
        private float? _total_amount;

        #endregion

        #region Accessors
       
        public long? ID
        {
            get { return _id; }
            private set { this._id = value; } //This Accessor must be removed after testing approvement.
        }
       
        public string PreferenceId
        {
            get { return _preference_id; }
            set { _preference_id = value; }
        }        

        public DateTime? DateCreated
        {
            get { return _date_created; }
            set { _date_created = value; }
        }

        

        public DateTime? LastUpdate
        {
            get { return _last_update; }            
            set { _last_update = value; }
        }

        public string ApplicationId
        {
            get { return _application_id; }
            set { _application_id = value; }
        }

        public string Status
        {
            get { return _status; }            
            set { _status = value;  }
        }

        public string SiteId
        {
            get { return _site_id; }
            set { _site_id = value; }
        }

        public Payer Payer
        {
            get { return _payer; }
            set { _payer = value; }
        }

        public Collector Collector
        {
            get { return _collector; }
            set { _collector = value; }
        }

        public long? SponsorId
        {
            get { return _sponsor_id; }
            set { _sponsor_id = value; }
        }

        public List<MerchantOrderPayment> Payments
        {
            get { return _payments; }
            set { _payments = value;  }
        }        

        public float? PaidAmount
        {
            get { return _paid_amount; }
            set { _paid_amount = value; }
        }
       
        public float? RefundedAmount
        {
            get { return _refunded_amount; }            
            set { _refunded_amount = value; }
        }

        public float? ShippingCost
        {
            get { return _shipping_cost; }            
            set { _shipping_cost = value; }
        }

        public bool? Cancelled
        {
            get { return _cancelled; }
            set { _cancelled = value; }
        }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void AppendItem(Item item)
        {
            if (_items == null)
            {
                _items = new List<Item>();
            }
            _items.Add(item);            
        }        

        public List<Shipment> Shipments
        {
            get { return _shipments; }
            set { _shipments = value; }
        }

        public void AppendShipment(Shipment shipment)
        {
            if (_shipments == null)
            {
                _shipments = new List<Shipment>();
            }
            _shipments.Add(shipment);            
        }

        public string NotificationUrl
        {
            get { return _notification_url; }
            set { _notification_url = value; }
        }

        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set { _additionalInfo = value; }
        }

        public string ExternalReference
        {
            get { return _external_reference; }
            set { _external_reference = value; }
        }

        public string Marketplace
        {
            get { return _marketplace; }
            set { _marketplace = value; }
        }
       
        public float? TotalAmount
        {
            get { return _total_amount; }
            set { _total_amount = value; }
        }

        #endregion
    }
}
