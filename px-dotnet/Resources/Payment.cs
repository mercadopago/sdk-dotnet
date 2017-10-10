using MercadoPago.Resources.DataStructures.Payment;
using Newtonsoft.Json;
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

        public Payment Load(string id)
        {
            return Load(id, WITHOUT_CACHE);
        }
        
        [GETEndpoint("/v1/payments/:id")]
        public static Payment Load(string id, bool useCache) 
        {
            return (Payment)ProcessMethod<Payment>(typeof(Payment), "Load", id, useCache);
        }
         
        [POSTEndpoint("/v1/payments")]
        public Payment Create()
        {
            return (Payment)ProcessMethod<Payment>("Create", WITHOUT_CACHE);
        }
        
        [PUTEndpoint("/v1/payments/:id")]
        public Payment Update()
        {
            return (Payment)ProcessMethod<Payment>("Update", WITHOUT_CACHE);
        }

        #endregion

        #region Properties

        private int? _id;
        private DateTime? _date_created;
        private DateTime? _date_approved;
        private DateTime? _date_last_updated;
        private DateTime? _money_release_date;
        private int? _collector_id;
        private string _operation_type;        
        private Payer _payer;
        private bool? _binary_mode;
        private bool? _live_mode;
        private Order _order ;
        private string _external_reference;
        private string _description;
        private JObject _metadata;              
        [StringLength(3)]
        private CurrencyId _currency_id;
        private decimal? _transaction_amount;
        private decimal? _transaction_amount_refunded;
        private decimal? _coupon_amount;
        private int? _campaign_id;
        private string _coupon_code;
        private TransactionDetail _transaction_details;
        private FeeDetail[] _fee_details;
        private int? _differential_pricing_id;
        private decimal? _application_fee;      
        private Status _status ;        
        private string _status_detail ;
        private bool? _capture ;
        private bool? _captured ;
        private string _call_for_authorize_id ;
        private string _payment_method_id ;
        private string _issuer_id ;       
        private string _payment_type_id ;        
        private string _token ;
        private Card _card ;
        private string _statement_descriptor ;
        private int? _installments ;
        private string _notification_url;
        private string _callback_url;
        private Refund[] _refunds ;
        private AdditionalInfo _additional_info ;

        public enum CurrencyId
        {
            ARS,
            BRL,
            VEF,
            CLP,
            MXN,
            COP,
            PEN,
            UYU
        }

        public enum Status
        {
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

        public enum PaymentTypeId
        {
            account_money,
            ticket,
            bank_transfer,
            atm,
            credit_card,
            debit_card,
            prepaid_card
        }

        #endregion

        #region Accessors

        public int? id 
        {
            get { return this._id; }
            private set { this._id = value; }
        }

        public DateTime? date_created 
        {
            get { return this._date_created; }
            private set { this._date_created = value; }
        }

        public DateTime? date_approved
        {
            get { return this._date_approved; }
            private set { this._date_approved = value; }
        }

        public DateTime? date_last_updated
        {
            get { return this._date_last_updated; }
            private set { this._date_last_updated = value; }
        }

        public DateTime? money_release_date
        {
            get { return this._money_release_date; }
            private set { this._money_release_date = value; }
        }

        public int? collector_id
        {
            get { return this._collector_id; }
            private set { this._collector_id = value; }
        }

        public string operation_type 
        {
            get { return this._operation_type; }
            private set { this._operation_type = value; }
        }

        public Payer payer 
        {
            get { return this._payer; }
            set { this._payer = value; }
        }

        public bool? binary_mode
        {
            get { return this._binary_mode; }
            set { this._binary_mode = value; }
        }

        public bool? live_mode
        {
            get { return this._live_mode; }
            private set { this._live_mode = value; }
        }

        public Order order
        {
            get { return this._order; }
            set { this._order = value; }
        }

        public string external_reference
        {
            get { return this._external_reference; }
            set { this._external_reference = value; }
        }

        public string description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public JObject metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        public CurrencyId currency_id
        {
            get { return this._currency_id; }
            private set { this._currency_id = value; }
        }

        public decimal? transaction_amount
        {
            get { return this._transaction_amount; }
            set { this._transaction_amount = value; }
        }

        public decimal? transaction_amount_refunded
        {
            get { return this._transaction_amount_refunded; }
            private set { this._transaction_amount_refunded = value; }
        }

        public decimal? coupon_amount
        {
            get { return this._coupon_amount; }
            set { this._coupon_amount = value; }
        }

        public int? campaign_id
        {
            private get { return this._campaign_id; }
            set { this._campaign_id = value; }
        }

        public string coupon_code
        {
            private get { return this._coupon_code; }
            set { this._coupon_code = value; }
        }

        public TransactionDetail transaction_details
        {
            get { return this._transaction_details; }
            private set { this._transaction_details = value; }
        }

        public FeeDetail[] fee_details
        {
            get { return this._fee_details; }
            private set { this._fee_details = value; }
        }

        public int? differential_pricing_id
        {
            get { return this._differential_pricing_id; }
            set { this._differential_pricing_id = value; }
        }

        public decimal? application_fee
        {
            private get { return this._application_fee; }
            set { this._application_fee = value; }
        }

        public Status status
        {
            get { return this._status; }
            private set { this._status = value; }
        }

        public string status_detail
        {
            get { return this._status_detail; }
            private set { this._status_detail = value; }
        }

        public bool? capture
        {
            private get { return this._capture; }
            set { this._capture = value; }
        }

        public bool? captured
        {
            get { return this._captured; }
            private set { this._captured = value; }
        }

        public string call_for_authorize_id
        {
            get { return this._call_for_authorize_id; }
            private set { this._call_for_authorize_id = value; }
        }

        public string payment_method_id
        {
            get { return this._payment_method_id; }
            set { this._payment_method_id = value; }
        }

        public string issuer_id
        {
            get { return this._issuer_id; }
            set { this._issuer_id = value; }
        }

        public string payment_type_id
        {
            get { return this._payment_type_id; }
            private set { this._payment_type_id = value; }
        }

        public string token
        {
            private get { return this._token; }
            set { this._token = value; }
        }

        public Card card
        {
            get { return this._card; }
            private set { this._card = value; }
        }

        public string statement_descriptor
        {
            get { return this._statement_descriptor; }
            set { this._statement_descriptor = value; }
        }

        public int? installments
        {
            get { return this._installments; }
            set { this._installments = value; }
        }

        public string notification_url
        {
            get { return this._notification_url; }
            set { this._notification_url = value; }
        }

        public string callback_url
        {
            get { return this._callback_url; }
            set { this._callback_url = value; }
        }

        public Refund[] refunds
        {
            get { return this._refunds; }
            private set { this._refunds = value; }
        }

        public AdditionalInfo additional_info
        {
            private get { return this._additional_info; }
            set { this._additional_info = value; }
        }
        
        #endregion
    }
}
