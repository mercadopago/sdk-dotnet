using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.MerchantOrder
{
    /// <summary>
    /// Payment information.
    /// </summary>
    public struct MerchantOrderPayment
    {
        #region Properties

        private string id;
        private float transactionAmount;
        private float totalPaidAmount;
        private float shippingCost;
       
        [StringLength(3)]
        private CurrencyId currencyId;
        private string status;
        private string statusDetail;
        public enum OperationType
        {
            RegularPayment,
            PaymentAddition
        }
        private OperationType operationType;
        private DateTime dateApproved;
        private DateTime dateCreated;
        private DateTime lastModified;
        private float amountRefunded;
        
        #endregion

        #region Accessors

        /// <summary>
        /// Payment ID.
        /// </summary>
        public string ID
        {
            get { return id; }            
        }
       
        /// <summary>
        /// Transaction amount.
        /// </summary>
        public float TransactionAmount
        {
            get { return transactionAmount; }            
        }
       
        /// <summary>
        /// Total paid amount.
        /// </summary>
        public float TotalPaidAmount
        {
            get { return totalPaidAmount; }            
        }
       
        /// <summary>
        /// Shipping cost.
        /// </summary>
        public float ShippingCost
        {
            get { return shippingCost; }            
        }
             
        /// <summary>
        /// Currency ID.
        /// </summary>
        public CurrencyId PaymentCurrencyId
        {
            get { return currencyId; }            
        }
       
        /// <summary>
        /// Payment status.
        /// </summary>
        public string Status
        {
            get { return status; }            
        }
       
        /// <summary>
        /// Status detail.
        /// </summary>
        public string StatusDetail
        {
            get { return statusDetail; }            
        }

        /// <summary>
        /// Operation type.
        /// </summary>
        public OperationType PaymentOperationType
        {
            get { return operationType; }            
        }
        
        /// <summary>
        /// Date of approvation.
        /// </summary>
        public DateTime DateApproved
        {
            get { return dateApproved; }            
        }
       
        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime DateCreated
        {
            get { return dateCreated; }            
        }        

        /// <summary>
        /// Date of last modified.
        /// </summary>
        public DateTime LastModified
        {
            get { return lastModified; }            
        }
       
        /// <summary>
        /// Amount refunded.
        /// </summary>
        public float AmountRefunded
        {
            get { return amountRefunded; }            
        }

        #endregion
    }
}
