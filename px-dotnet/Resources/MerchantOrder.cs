using MercadoPago.DataStructures.MerchantOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    /// <summary>
    /// This class will allow you to create and manage your orders. You can attach one or more payments in your merchant order.
    /// </summary>
    public class MerchantOrder : MPBase
    {
        #region Actions
        
        /// <summary>
        /// Load the merchant order data.
        /// </summary>
        /// <param name="id">Merchant order ID.</param>
        /// <returns>The merchant order data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/get/">here</a>.
        /// </remarks>
        public MerchantOrder Load(string id) 
        {
            return Load(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Load the merchant order data.
        /// </summary>
        /// <param name="id">Merchant order ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The merchant order data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/merchant_orders/:id")]
        public MerchantOrder Load(string id, bool useCache, MPRequestOptions requestOptions)
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>(typeof(MerchantOrder), "Load", id, useCache, requestOptions);
        }

        /// <summary>
        /// Saves a new merchant order.
        /// </summary>
        /// <returns>The saved merchant order.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders/post/">here</a>.
        /// </remarks>
        public MerchantOrder Save()
        {
            return Save(null);
        }
        
        /// <summary>
        /// Saves a new merchant order.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The saved merchant order.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders/post/">here</a>.
        /// </remarks>
        [POSTEndpoint("/merchant_orders")]
        public MerchantOrder Save(MPRequestOptions requestOptions) 
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Updates the merchant order.
        /// </summary>
        /// <returns>The updated merchant order.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/put/">here</a>.
        /// </remarks>
        public MerchantOrder Update()
        {
            return Update(null);
        }
        
        /// <summary>
        /// Updates the merchant order.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The updated merchant order.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/put/">here</a>.
        /// </remarks>
        [PUTEndpoint("/merchant_orders/:id")]
        public MerchantOrder Update(MPRequestOptions requestOptions)
        {
            return (MerchantOrder)ProcessMethod<MerchantOrder>("Update", WITHOUT_CACHE, requestOptions);
        }

        #endregion

        #region Properties

        private string id;
        private string preferenceId;
        private DateTime? dateCreated;
        private DateTime? lastUpdate;
        private string applicationId;
        private string status;
        private string siteId;
        private Payer payer;
        private Collector collector;
        private long? sponsorId;
        private List<MerchantOrderPayment> payments;
        private float? paidAmount;
        private float? refundedAmount;
        private float? shippingCost;
        private bool? cancelled;
        private List<Item> items;
        private List<Shipment> shipments;
        [StringLength(500)]
        private string notificationUrl;
        [StringLength(600)]
        private string additionalInfo;
        [StringLength(256)]
        private string externalReference;
        [StringLength(256)]
        private string marketplace;
        private float? totalAmount;

        #endregion

        #region Accessors
       
        /// <summary>
        /// Merchant order ID.
        /// </summary>
        public string ID
        {
            get { return id; }
            set { this.id = value; } //This Accessor must be removed after testing approvement.
        }
       
        /// <summary>
        /// Payment preference identifier associated to the merchant order.
        /// </summary>
        public string PreferenceId
        {
            get { return preferenceId; }
            set { preferenceId = value; }
        }        

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated
        {
            get { return dateCreated; }            
        }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? LastUpdate
        {
            get { return lastUpdate; }            
        }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId
        {
            get { return applicationId; }
            set { applicationId = value; }
        }

        /// <summary>
        /// Show the current merchant order state.
        /// </summary>
        public string Status
        {
            get { return status; }            
        }

        /// <summary>
        /// Country identifier that merchant order belongs to.
        /// </summary>
        public string SiteId
        {
            get { return siteId; }
            set { siteId = value; }
        }

        /// <summary>
        /// Payer information.
        /// </summary>
        public Payer Payer
        {
            get { return payer; }
            set { payer = value; }
        }

        /// <summary>
        /// Seller information.
        /// </summary>
        public Collector Collector
        {
            get { return collector; }
            set { collector = value; }
        }

        /// <summary>
        /// Sponsor ID.
        /// </summary>
        public long? SponsorId
        {
            get { return sponsorId; }
            set { sponsorId = value; }
        }

        /// <summary>
        /// Payments information.
        /// </summary>
        public List<MerchantOrderPayment> Payments
        {
            get { return payments; }            
        }        

        /// <summary>
        /// Amount paid in this order.
        /// </summary>
        public float? PaidAmount
        {
            get { return paidAmount; }            
        }
       
        /// <summary>
        /// Amount refunded in this Order.
        /// </summary>
        public float? RefundedAmount
        {
            get { return refundedAmount; }            
        }

        /// <summary>
        /// Shipping fee.
        /// </summary>
        public float? ShippingCost
        {
            get { return shippingCost; }            
        }

        /// <summary>
        /// If the Order is expired (<c>true</c>) or not (<c>false</c>).
        /// </summary>
        public bool? Cancelled
        {
            get { return cancelled; }
            set { cancelled = value; }
        }

        /// <summary>
        /// Items information.
        /// </summary>
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        /// <summary>
        /// Appends a item.
        /// </summary>
        public void AppendItem(Item item)
        {
            if (items == null)
            {
                items = new List<Item>();
            }
            items.Add(item);            
        }        

        /// <summary>
        /// Shipments information.
        /// </summary>
        public List<Shipment> Shipments
        {
            get { return shipments; }
            set { shipments = value; }
        }

        /// <summary>
        /// Appends shipment information.
        /// </summary>
        public void AppendShipment(Shipment shipment)
        {
            if (shipments == null)
            {
                shipments = new List<Shipment>();
            }
            shipments.Add(shipment);            
        }

        /// <summary>
        /// URL where you'd like to receive a payment notification.
        /// </summary>
        public string NotificationUrl
        {
            get { return notificationUrl; }
            set { notificationUrl = value; }
        }

        /// <summary>
        /// Additional information.
        /// </summary>
        public string AdditionalInfo
        {
            get { return additionalInfo; }
            set { additionalInfo = value; }
        }

        /// <summary>
        /// Reference you can synchronize with your payment system.
        /// </summary>
        public string ExternalReference
        {
            get { return externalReference; }
            set { externalReference = value; }
        }

        /// <summary>
        /// Origin of the payment.
        /// </summary>
        public string Marketplace
        {
            get { return marketplace; }
            set { marketplace = value; }
        }
       
        /// <summary>
        /// Total amount of the order.
        /// </summary>
        public float? TotalAmount
        {
            get { return totalAmount; }
        }

        #endregion
    }
}
