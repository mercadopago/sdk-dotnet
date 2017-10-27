using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct TransactionDetail
    {
        #region Properties

        private string financialInstitution;
        private float netReceivedAmount;
        private float totalPaidAmount;
        private float installmentAmount;
        private float overpaidAmount;
        private string externalResourceUrl;
        private string paymentMethodReferenceId;

        #endregion

        #region Accessors

        public string FinancialInstitution
        {
            get { return financialInstitution; }            
        }
        
        public float NetReceivedAmount
        {
            get { return netReceivedAmount; }            
        }
       
        public float TotalPaidAmount
        {
            get { return totalPaidAmount; }            
        }
       
        public float InstallmentAmount
        {
            get { return installmentAmount; }            
        }
       
        public float OverpaidAmount
        {
            get { return overpaidAmount; }            
        }
        
        public string ExternalResourceUrl
        {
            get { return externalResourceUrl; }            
        }
       
        public string PaymentMethodReferenceId
        {
            get { return paymentMethodReferenceId; }
        }

        #endregion
    }
}
