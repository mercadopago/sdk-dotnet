using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct MerchantOrderPayment
    {
        #region Properties

        private long? _id;
        private float _transaction_amount;
        private float _total_paid_amount;
        private float _shipping_cost;
       
        [StringLength(3)]
        private CurrencyId _currency_id;
        private string _status;
        private string _status_detail;
        public enum OperationType
        {
            RegularPayment,
            PaymentAddition
        }
        private OperationType _operation_type;
        private DateTime _date_approved;
        private DateTime _date_created;
        private DateTime _last_modified;
        private float _amount_refunded;
        
        #endregion

        #region Accessors

        public long? ID
        {
            get { return _id; } 
            private set { _id = value; }
        }
       
        public float TransactionAmount
        {
            get { return _transaction_amount; }            
            set { _transaction_amount = value; }
        }
       
        public float TotalPaidAmount
        {
            get { return _total_paid_amount; }            
            set { _total_paid_amount = value; }
        }
       
        public float ShippingCost
        {
            get { return _shipping_cost; }
            set { _shipping_cost = value; }
        }
             
        public CurrencyId PaymentCurrencyId
        {
            get { return _currency_id; }            
            set { _currency_id = value; }
        }
       
        public string Status
        {
            get { return _status; }            
            set { _status = value; }
        }
       
        public string StatusDetail
        {
            get { return _status_detail; }            
            set { _status_detail = value; }
        }

        public OperationType PaymentOperationType
        {
            get { return _operation_type; }            
            set { _operation_type = value; }
        }
        
        public DateTime DateApproved
        {
            get { return _date_approved; }            
            set { _date_approved = value; }
        }
       
        public DateTime DateCreated
        {
            get { return _date_created; }
            set { _date_created = value; }
        }        

        public DateTime LastModified
        {
            get { return _last_modified; }            
            set { _last_modified = value; }
        }
       
        public float AmountRefunded
        {
            get { return _amount_refunded; }
            set { _amount_refunded = value; }
        }

        #endregion
    }
}
