using MercadoPago.Resources.DataStructures.Payment;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    public class Payment : MPBase
    {
        #region Actions

        public Payment Load(String id) 
        {
            return Load(id, WITHOUT_CACHE);
        }
        
        [GETEndpoint("/v1/payment/:id")]
        public static Payment Load(String id, Boolean useCache) 
        {
            return (Payment)ProcessMethod(typeof(Payment), "Load", id, useCache);
        }
        
        [POSTEndpoint("/v1/payment")]
        public Payment Save()
        {
            return (Payment)ProcessMethod("Create", WITHOUT_CACHE);
        }
        
        [PUTEndpoint("/v1/payment/:id")]
        public Payment Update()
        {
            return (Payment)ProcessMethod<Payment>("Update", WITHOUT_CACHE);
        }

        #endregion

        #region Properties

        private string id ;
        private DateTime? dateTimeCreated;
        private DateTime? dateTimeApproved;
        private DateTime? dateTimeLastUpdateTimed;
        private DateTime? moneyReleaseDateTime;
        private int collectorId ;

        public enum OperationType {regular_payment,
            money_transfer,
            recurring_payment,
            account_fund,
            payment_addition,
            cellphone_recharge,
            pos_payment
        }
        
        private OperationType operationType;
        
        private Payer payer;
        private bool? binaryMode ;
        private bool? liveMode ;
        private Order order ;
        private string externalReference;
        private string description;
        private JObject metadata;
        
        public enum CurrencyId {
            ARS,
            BRL,
            VEF,
            CLP,
            MXN,
            COP,
            PEN,
            UYU
        }
        
        [StringLength(3)]
        private CurrencyId currencyId ;        
        private decimal? transactionAmount ;
        private decimal? transactionAmountRefunded;
        private decimal? couponAmount;
        private int? campaignId;
        private string couponCode ;
        private TransactionDetail transactionDetail;
        private List<FeeDetail> feeDetails;
        private int? differentialPricingId;
        private decimal? applicationFee;
        
        public enum Status {
            pending,
            approved,
            authorized,
            in_process,
            in_mediation,
            rejected,
            cancelled,
            refunded,
            charged_back
        }

        private Status status ;        
        private string statusDetail ;
        private bool? capture ;
        private bool? captured ;
        private string callForAuthorizeId ;
        private string paymentMethodId ;
        private string issuerId ;
        
        public enum PaymentTypeId {
            account_money,
            ticket,
            bank_transfer,
            atm,
            credit_card,
            debit_card,
            prepaid_card
        }

        private PaymentTypeId paymentTypeId ;
        
        private string token ;
        private Card card ;
        private string statementDescriptor ;
        [RegularExpression(@"^\n+\.\d{0,0}$")]
        [Range(0, 9)]
        private int? installment ;
        private string notificationUrl ;
        private List<Refund> refunds ;
        private AdditionalInfo additionalInfo ;

        #endregion

        #region Accessors
        
        public string ID 
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public DateTime? DateTimeCreated 
        {
            get { return this.dateTimeCreated; }
            set { this.dateTimeCreated = value; }
        }

        public DateTime? DateTimeApproved
        {
            get { return this.dateTimeApproved; }
            set { this.dateTimeApproved = value; }
        }

        public DateTime? DateTimeLastUpdateTimed
        {
            get { return this.dateTimeLastUpdateTimed; }
            set { this.dateTimeLastUpdateTimed = value ; }
        }

        public DateTime? MoneyReleaseDateTime
        {
            get { return this.moneyReleaseDateTime; }
            set { this.moneyReleaseDateTime = value; }
        }

        public OperationType PaymentOperationType 
        {
            get { return this.operationType; }
            set { this.operationType = value; }
        }

        public Payer Payer 
        {
            get { return this.payer; }
            set { this.payer = value; }
        }

        public bool? BinaryMode
        {
            get { return this.binaryMode; }
            set { this.binaryMode = value; }
        }

        public bool? LiveMode
        {
            get { return this.liveMode; }
            set { this.liveMode = value; }
        }

        public Order Order 
        {
            get { return this.order; }
            set { this.order = value; }
        }

        public string ExternalReference
        {
            get { return this.externalReference; }
            set { this.externalReference = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public JObject Metadata 
        {
            get { return this.metadata; }
            set { this.metadata = value; }
        }

        public CurrencyId PaymentCurrencyId
        {
            get { return this.currencyId; }
        }

        public decimal? TransactionAmount
        {
            get { return this.transactionAmount; }
            set { this.transactionAmount = value; }
        }

        public decimal? TransactionAmountRefunded
        {
            get { return this.transactionAmountRefunded; }
        }

        public decimal? CouponAmount
        {
            get { return this.couponAmount; }
            set { this.couponAmount = value; }
        }

        public int CampaignId
        {
            set { this.campaignId = value; }
        }
        
        public string CouponCode
        {
            set { this.couponCode = value; }
        }

        public TransactionDetail TransactionDetail 
        {
            get { return this.transactionDetail; }
        }

        public List<FeeDetail> FeeDetails
        {
            get { return this.feeDetails; }
        }

        public int? DifferentialPricingId
        {
            get { return this.differentialPricingId; }
            set { this.differentialPricingId = value; }
        }
        
        public decimal ApplicationFee
        {
            set { this.applicationFee = value; }
        }

        public Status PaymentStatus
        {
            get { return this.status; }
        }

        public string StatusDetail
        {
            get { return this.statusDetail; }
        }

        public bool Capture
        {
            set { this.capture = value; }
        }

        public bool? Captured
        {
            get { return this.captured; }
        }

        public string CallForAuthorizeId 
        {
            get { return this.callForAuthorizeId; }
        }

        public string PaymentMethodId
        {
            get { return this.paymentMethodId; }
            set { this.paymentMethodId = value; }
        }

        public string IssuerId
        {
            get { return this.issuerId; }
            set { this.issuerId = value; }
        }

        public PaymentTypeId TypeId
        {
            get { return this.paymentTypeId; }
            set { this.paymentTypeId = value; }
        }

        public string Token
        {
            set { this.token = value; }
        }

        public Card Card
        {
            get { return this.card; }
        }

        public string StatementDescriptor
        {
            get { return this.statementDescriptor; }
            set { this.statementDescriptor = value; }
        }

        public int? Installment
        {
            get { return this.installment; }
            set { this.installment = value; }
        }

        public string NotificationUrl
        {
            get { return this.notificationUrl; }
            set { this.notificationUrl = value; }
        }

        public List<Refund> Refunds
        {
            get { return this.refunds; }
        }

        public AdditionalInfo AdditionalInfo
        {
            set { this.additionalInfo = value; }
        }
        
        #endregion
    }
}
