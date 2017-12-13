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
        private List<PaymentMethod> _excluded_payment_methods;
        private List<PaymentType> _excluded_payment_types; 
        [StringLength(256)]
        private string _default_payment_method_id;
        private int? _installments;
        private int? _default_installments; 
        #endregion

        #region Accessors 
        /// <summary>
        /// Payment methods not allowed in payment process (except account_money)
        /// </summary>
        public List<PaymentMethod> ExcludedPaymentMethods
        {
            get
            {
                return _excluded_payment_methods;
            }

            set
            {
                _excluded_payment_methods = value;
            }
        }
        /// <summary>
        /// Payment types not allowed in payment process
        /// </summary>
        public List<PaymentType> ExcludedPaymentTypes
        {
            get
            {
                return _excluded_payment_types;
            }

            set
            {
                _excluded_payment_types = value;
            }
        }
        /// <summary>
        /// Payment method to be preferred on the payments methods list
        /// </summary>
        public string DefaultPaymentMethodId
        {
            get
            {
                return _default_payment_method_id;
            }

            set
            {
                _default_payment_method_id = value;
            }
        }
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
        public int? DefaultInstallments
        {
            get
            {
                return _default_installments;
            }

            set
            {
                _default_installments = value;
            }
        } 
        #endregion

    }
}
