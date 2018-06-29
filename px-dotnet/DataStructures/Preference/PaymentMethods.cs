using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct PaymentMethods
    {
        #region Properties 

        private int? _installments;

        #endregion

        #region Accessors 
        /// <summary>
        /// Payment methods not allowed in payment process (except account_money)
        /// </summary>
        public List<PaymentMethod> ExcludedPaymentMethods { get; set; }

        /// <summary>
        /// Payment types not allowed in payment process
        /// </summary>
        public List<PaymentType> ExcludedPaymentTypes { get; set; }

        /// <summary>
        /// Payment method to be preferred on the payments methods list
        /// </summary>
        [StringLength(256)]
        public string DefaultPaymentMethodId { get; set; }

        /// <summary>
        /// Maximum number of credit card installments to be accepted
        /// </summary> 
        public int? Installments
        {
            get
            {
                return _installments ?? 1;
            }

            set
            {
                _installments = value;
            }
        }
        /// <summary>
        /// Prefered number of credit card installments
        /// </summary>
        public int? DefaultInstallments { get; set; }

        #endregion

    }
}
