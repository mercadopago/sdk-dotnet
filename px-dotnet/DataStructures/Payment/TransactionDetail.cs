using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public class TransactionDetail
    {
        #region Properties

        private string financialInstitution;
        private decimal netReceivedAmount;
        private decimal totalPaidAmount;
        private decimal installmentAmount;
        private decimal overpaidAmount;
        private string externalResourceUrl;
        private string paymentMethodReferenceId;

        #endregion

        #region Accessors

        public string FinancialInstitution
        {
            get { return financialInstitution; }            
        }
        
        public decimal NetReceivedAmount
        {
            get { return netReceivedAmount; }            
        }
       
        public decimal TotalPaidAmount
        {
            get { return totalPaidAmount; }            
        }
       
        public decimal InstallmentAmount
        {
            get { return installmentAmount; }            
        }
       
        public decimal OverpaidAmount
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
