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

        public static Preference Load(string id)
        {
            return Load(id, WITHOUT_CACHE);
        }

        [GETEndpoint("/checkout/preferences/:id")]
        public static Preference Load(string id, bool useCache)
        {            
            return (Preference)ProcessMethod(typeof(Preference), "Load", id, useCache);
        }

        [POSTEndpoint("/checkout/preferences")]
        public Preference Create()
        {
            return (Preference)ProcessMethod("Create", WITHOUT_CACHE);
        }

        [PUTEndpoint("/checkout/preferences/:id")]
        public Preference Update()
        {
            return (Preference)ProcessMethod("update", WITHOUT_CACHE);
        }        
                
        #endregion

        #region Properties

        private List<Item> items = null;
        private Payer payer = null;
        private PaymentMethod paymentMethod = null;
        private Shipment shipment = null;
        private BackUrl backUrl = null;

        [StringLength(500)]
        private string notificationUrl = null;
        private string id = null;
        private string initPoint = null;
        private string sandboxInitPoint = null;
        private DateTime? dateCreated = null;
        
        private OperationTypes? operationType = null;

        [StringLength(600)]
        private string additionalInfo = null;
        private AutoReturnTypes? autoReturn = null;
        [StringLength(256)]
        private string externalReference = null;
        private bool? expires = null;
        private DateTime? expirationDateFrom = null;
        private DateTime? expirationDateTo = null;
        private int? collectorId = null;
        private int? clientId = null;

        [StringLength(256)]
        private string marketplace = null;

        private float? marketplaceFee = null;
        private DifferentialPricing differentialPricing = null;
        
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

        public DateTime DateCreated 
        { 
            get { return this.dateCreated.Value; } 
            set { this.dateCreated = value; } 
        }
        
        private enum OperationTypes { RegularPayment, MoneyTransfer }
        
        public OperationTypes OperationType 
        { 
            get { return this.operationType.Value; }
            set { this.operationType = value; } 
        }                
        
        public string AdditionalInfo 
        { 
            get { return this.additionalInfo; } 
            set { this.additionalInfo = value; } 
        }
        
        private enum AutoReturnTypes { Approved, All }
        
        public AutoReturnTypes AutoReturn 
        { 
            get { return this.autoReturn.Value; } 
            set { this.autoReturn = value; } 
        }
        
        public string ExternalReference 
        { 
            get { return this.externalReference; } 
            set { this.externalReference = value; } 
        }

        public bool Expires 
        { 
            get { return this.expires.Value; } 
            set { this.expires = value; } 
        }

        public DateTime ExpirationDateFrom 
        { 
            get { return this.expirationDateFrom.Value; } 
            set { this.expirationDateFrom = value; } 
        }
        
        public DateTime ExpirationDateTo 
        { 
            get { return this.expirationDateTo.Value; } 
            set { this.expirationDateTo = value; } 
        }

        public int CollectorId 
        { 
            get { return this.collectorId.Value; } 
            set { this.collectorId = value; } 
        }
        
        public int ClientId 
        { 
            get { return this.clientId.Value; } 
            set { this.clientId = value; } 
        }
        
        public string Marketplace 
        { 
            get { return this.marketplace; } 
            set { this.marketplace = value; } 
        }
        
        public float MarketplaceFee 
        { 
            get { return this.marketplaceFee.Value; } 
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
