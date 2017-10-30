using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct TransactionDetail
    {
        #region Properties 
        private string _financial_institution;
        private float _net_received_amount;
        private float _total_paid_amount;
        private float _installment_amount;
        private float _overpaid_amount;
        private string _external_resource_url;
        private string _payment_method_reference_id; 
        #endregion

        #region Accessors 
        /// <summary>
        /// External financial institution identifier (e.g.: company id for atm)
        /// </summary>
        public string FinancialInstitution { 
            get => _financial_institution; 
            set => _financial_institution = value; 
        }
        /// <summary>
        /// Amount received by the seller
        /// </summary>
        public float NetReceivedAmount { 
            get => _net_received_amount; 
            set => _net_received_amount = value; 
        }
        /// <summary>
        /// Total amount paid by the buyer (includes fees)
        /// </summary>
        public float TotalPaidAmount { 
            get => _total_paid_amount; 
            set => _total_paid_amount = value; 
        }
        /// <summary>
        /// Total installments amount
        /// </summary>
        public float InstallmentAmount { 
            get => _installment_amount; 
            set => _installment_amount = value; 
        }
        /// <summary>
        /// Amount overpaid (only for tickets)
        /// </summary>
        public float OverpaidAmount { 
            get => _overpaid_amount; 
            set => _overpaid_amount = value; 
        }
        /// <summary>
        /// Identifies the resource in the payment processor
        /// </summary>
        public string ExternalResourceUrl { 
            get => _external_resource_url; 
            set => _external_resource_url = value; 
        }
        /// <summary>
        /// For credit card payments is the USN. For offline payment methods, 
        /// is the reference to give to the cashier or to input into the ATM.
        /// </summary>
        public string PaymentMethodReferenceId { 
            get => _payment_method_reference_id; 
            set => _payment_method_reference_id = value; 
        } 
        #endregion
    }
}
