using MercadoPago.Resources.DataStructures.Preference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    public class Preference : MPBase
    {
        #region Actions

        public Preference Load(string id)
        {
            return Load(id, WITHOUT_CACHE);
        }

        [GETEndpoint("/checkout/preference/:id")]
        public static Preference Load(string id, bool useCache)
        {            
            return (Preference)ProcessMethod<Preference>(typeof(Preference), "Load", id, useCache);
        }

        [POSTEndpoint("/checkout/preference")]
        public Preference Save()
        {
            return (Preference)ProcessMethod("Create", WITHOUT_CACHE);
        }

        [PUTEndpoint("/checkout/preference/:id")]
        public Preference Update()
        {
            return (Preference)ProcessMethod<Preference>("Update", WITHOUT_CACHE);
        }        
                
        #endregion

        #region Properties

        private List<Item> items;
        private Payer payer;
        private PaymentMethod paymentMethod;
        private Shipment shipment;
        private BackUrl backUrl;

        [StringLength(500)]
        private string notificationUrl;
        private string id;
        private string initPoint;
        private string sandboxInitPoint;
        private DateTime? dateCreated;

        public enum OperationTypes
        {
            RegularPayment,
            MoneyTransfer
        }

        private OperationTypes operationType;

        [StringLength(600)]
        private string additionalInfo;
        private AutoReturnTypes autoReturn;
        [StringLength(256)]
        private string externalReference;
        private bool? expires;
        private DateTime? expirationDateFrom;
        private DateTime? expirationDateTo;
        private int? collectorId;
        private int? clientId;

        [StringLength(256)]
        private string marketplace;

        private float marketplaceFee;
        private DifferentialPricing differentialPricing;        
        
        #endregion

        #region Accesors

        public List<Item> Items 
        { 
            get { return this.items; } 
            set { this.items = value; } 
        }
        
        public Payer Payer 
        { 
            get { return this.payer; } 
            set { this.payer = value; } 
        }
        
        public PaymentMethod PaymentMethod 
        { 
            get { return this.paymentMethod; } 
            set{ this.paymentMethod = value; } 
        }

        public Shipment Shipment 
        { 
            get { return this.shipment; } 
            set { this.shipment = value; } 
        }
        
        public BackUrl BackUrl { 
            get { return this.backUrl; } 
            set { this.backUrl = value; } 
        }
        
        public string NotificationUrl 
        { 
            get { return this.notificationUrl; } 
            set { this.notificationUrl = value; } 
        }
        
        public string ID 
        { 
            get { return this.id; } 
            set { this.id = value; } 
        }
        
        public string InitPoint 
        { 
            get { return this.initPoint; } 
            set { this.initPoint = value; } 
        }
        
        public string SandboxInitPoint 
        { 
            get { return this.sandboxInitPoint; } 
            set { this.sandboxInitPoint = value; } 
        }

        public DateTime? DateCreated 
        { 
            get { return this.dateCreated; } 
            set { this.dateCreated = value; } 
        }               
        
        public OperationTypes OperationType 
        { 
            get { return this.operationType; }
            set { this.operationType = value; } 
        }                
        
        public string AdditionalInfo 
        { 
            get { return this.additionalInfo; } 
            set { this.additionalInfo = value; } 
        }
        
        public enum AutoReturnTypes { Approved, All }
        
        public AutoReturnTypes AutoReturn 
        { 
            get { return this.autoReturn; } 
            set { this.autoReturn = value; } 
        }
        
        public string ExternalReference 
        { 
            get { return this.externalReference; } 
            set { this.externalReference = value; } 
        }

        public bool? Expires 
        { 
            get { return this.expires; } 
            set { this.expires = value; } 
        }

        public DateTime? ExpirationDateFrom 
        { 
            get { return this.expirationDateFrom; } 
            set { this.expirationDateFrom = value; } 
        }
        
        public DateTime? ExpirationDateTo 
        { 
            get { return this.expirationDateTo; } 
            set { this.expirationDateTo = value; } 
        }

        public int? CollectorId 
        { 
            get { return this.collectorId; } 
            set { this.collectorId = value; } 
        }
        
        public int? ClientId 
        { 
            get { return this.clientId; } 
            set { this.clientId = value; } 
        }
        
        public string Marketplace 
        { 
            get { return this.marketplace; } 
            set { this.marketplace = value; } 
        }
        
        public float MarketplaceFee 
        { 
            get { return this.marketplaceFee; } 
            set { this.marketplaceFee = value; } 
        }
        
        public DifferentialPricing DifferentialPricing 
        { 
            get { return this.differentialPricing; } 
            set { this.differentialPricing = value; } 
        }

        #endregion
    }
}
