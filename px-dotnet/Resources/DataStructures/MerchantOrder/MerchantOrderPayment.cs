using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.MerchantOrder
{
    public class MerchantOrderPayment
    {
        #region Properties

        private string id;
        private decimal transactionAmount;
        private decimal totalPaidAmount;
        private decimal shippingCost;
        public enum CurrencyId
        {
            ARS,
            BRL,
            VEF,
            CLP,
            MXN,
            COP,
            UYU
        }
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
        private decimal amountRefunded;
        
        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
       
        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }
       
        public decimal TotalPaidAmount
        {
            get { return totalPaidAmount; }
            set { totalPaidAmount = value; }
        }
       
        public decimal ShippingCost
        {
            get { return shippingCost; }
            set { shippingCost = value; }
        }
             
        public CurrencyId CurrencyId
        {
            get { return currencyId; }
            set { currencyId = value; }
        }
       
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
       
        public string StatusDetail
        {
            get { return statusDetail; }
            set { statusDetail = value; }
        }
               
        public OperationType OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }
        
        public DateTime DateApproved
        {
            get { return dateApproved; }
            set { dateApproved = value; }
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
       
        public decimal AmountRefunded
        {
            get { return amountRefunded; }
            set { amountRefunded = value; }
        }

        #endregion
    }
}
