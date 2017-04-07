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

        public static Payment Load(String id) 
        {
            return Load(id, WITHOUT_CACHE);
        }
        
        [GETEndpoint("/v1/payments/:id")]
        public static Payment Load(String id, Boolean useCache) 
        {
            return (Payment)ProcessMethod(typeof(Payment), "Load", id, useCache);
        }
        
        [POSTEndpoint("/v1/payments")]
        public Payment Create()
        {
            return (Payment)ProcessMethod("Create", WITHOUT_CACHE);
        }
        
        [PUTEndpoint("/v1/payments/:id")]
        public Payment Update()
        {
            return (Payment)ProcessMethod("Update", WITHOUT_CACHE);
        }

        #endregion

        #region Properties

        private string id = null;
        private DateTime? dateTimeCreated = null;
        private DateTime? dateTimeApproved = null;
        private DateTime? dateTimeLastUpdateTimed = null;
        private DateTime? moneyReleaseDateTime = null;
        private int? collectorId = null;

        public enum OperationType {regular_payment,
            money_transfer,
            recurring_payment,
            account_fund,
            payment_addition,
            cellphone_recharge,
            pos_payment
        }
        
        private OperationType? operationType = null;
        
        private Payer payer = null;
        private bool? binaryMode = null;
        private bool? liveMode = null;
        private Order order = null;
        private string externalReference = null;
        private string description = null;
        private JObject metadata = null;
        
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
        private CurrencyId? currencyId = null;        
        private decimal? transactionAmount = null;
        private decimal? transactionAmountRefunded = null;
        private decimal? couponAmount = null;
        private int? campaignId = null;
        private string couponCode = null;
        private TransactionDetails transactionDetails = null;
        private List<FeeDetail> feeDetails = null;
        private int? differentialPricingId = null;
        private decimal? applicationFee = null;
        
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

        private Status? status = null;        
        private string statusDetail = null;
        private bool? capture = null;
        private bool? captured = null;
        private string callForAuthorizeId = null;
        private string paymentMethodId = null;
        private string issuerId = null;
        
        public enum PaymentTypeId {
            account_money,
            ticket,
            bank_transfer,
            atm,
            credit_card,
            debit_card,
            prepaid_card
        }

        private PaymentTypeId? paymentTypeId = null;
        
        private string token = null;
        private Card card = null;
        private string statementDescriptor = null;
        [RegularExpression(@"^\n+\.\d{0,0}$")]
        [Range(0, 9)]
        private int? installment = null;
        private string notificationUrl = null;
        private List<Refund> refunds = null;
        private AdditionalInfo additionalInfo = null;

        #endregion

        #region Accessors
        
        public string ID 
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public DateTime DateTimeCreated 
        {
            get { return this.dateTimeCreated.Value; }
            set { this.dateTimeCreated = value; }
        }

        public DateTime DateTimeApproved
        {
            get { return this.dateTimeApproved.Value; }
            set { this.dateTimeApproved = value; }
        }

        public DateTime DateTimeLastUpdateTimed
        {
            get { return this.dateTimeLastUpdateTimed.Value; }
            set { this.dateTimeLastUpdateTimed = value ; }
        }

        public DateTime MoneyReleaseDateTime
        {
            get { return this.moneyReleaseDateTime.Value; }
            set { this.moneyReleaseDateTime = value; }
        }

        public OperationType OperationType 
        {
            get { return this.operationType.Value; }
            set { this.operationType = value; }
        }

        public Payer Payer 
        {
            get { return this.payer; }
            set { this.payer = value; }
        }

        public bool BinaryMode
        {
            get { return this.binaryMode.Value; }
            set { this.binaryMode = value; }
        }

        public bool LiveMode
        {
            get { return this.liveMode.Value; }
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

        public CurrencyId CurrencyId
        {
            get { return this.currencyId.Value; }
        }

        public decimal TransactionAmount
        {
            get { return this.transactionAmount.Value; }
            set { this.transactionAmount = value; }
        }

        public decimal TransactionAmountRefunded
        {
            get { return this.transactionAmountRefunded.Value; }
        }

        public decimal CouponAmount
        {
            get { return this.couponAmount.Value; }
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
            get { return this.TransactionDetail; }
        }

        public List<FeeDetail> FeeDetails
        {
            get { return this.feeDetails; }
        }

        public int DifferentialPricingId
        {
            get { return this.differentialPricingId.Value; }
            set { this.differentialPricingId = value; }
        }
        
        public decimal ApplicationFee
        {
            set { this.applicationFee = value; }
        }

        public Status Status
        {
            get { return this.status.Value; }
        }

        public string StatusDetail
        {
            get { return this.statusDetail; }
        }

        public bool Capture
        {
            set { this.capture = value; }
        }

        public bool Captured
        {
            get { return this.captured.Value; }
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

        public PaymentTypeId PaymentTypeId
        {
            get { return this.paymentTypeId.Value; }
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

        public int Installment
        {
            get { return this.installment.Value; }
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
