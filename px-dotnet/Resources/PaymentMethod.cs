using System;
using System.Collections.Generic;
using MercadoPago.Common;
using MercadoPago.DataStructures.PaymentMethod;

namespace MercadoPago.Resources
{
    public class PaymentMethod : MPBase
    {

        #region Actions

        /// <summary>
        /// Get All Payment Methods available
        /// </summary>
        public static List<PaymentMethod> All()
        {
            return All(WITHOUT_CACHE);
        }

        /// <summary>
        /// Get All Payment Methods available
        /// </summary>
        [GETEndpoint("/v1/payment_methods")]
        public static List<PaymentMethod> All(bool useCache)
        {
            return (List<PaymentMethod>)ProcessMethodBulk<PaymentMethod>(typeof(PaymentMethod), "All", useCache);
        }

        #endregion

        #region Properties
        private string _id;
        private string _name;
        private PaymentTypeId _payment_type_id;
        private PaymentMethodStatus _status;
        private string _secure_thumbail;
        private string _thumbail;
        private PaymentMethodDeferredCapture _deferred_capture;
        private List<Settings> _settings;
        private List<String> _additional_info_needed;
        private string _min_allowed_amount;
        private string _max_allowed_amount;
        private string _accreditation_time;
        private List<String> _financial_institutions;
        private List<String> _processing_mode;
        #endregion

        #region Accessors

        /// <summary>
        /// Payment method identifier
        /// </summary>
        public string Id
        {
            get { return _id; } 
            set { _id = value; }
        }

        /// <summary>
        /// Name of the payment method
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Types of payment methods
        /// </summary>
        public PaymentTypeId PaymentTypeId
        {
            get
            {
                return _payment_type_id;
            }

            set
            {
                _payment_type_id = value;
            }
        }

        /// <summary>
        /// Payment methods status
        /// </summary>
        public PaymentMethodStatus Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        /// <summary>
        /// Logo to display on secure sites
        /// </summary>
        public string SecureThumbail
        {
            get
            {
                return _secure_thumbail;
            }

            set
            {
                _secure_thumbail = value;
            }
        }

        /// <summary>
        /// Logo to show
        /// </summary>
        public string Thumbail
        {
            get
            {
                return _thumbail;
            }

            set
            {
                _thumbail = value;
            }
        }

        /// <summary>
        /// Whether the capture can be delayed or not
        /// </summary> 
        public PaymentMethodDeferredCapture DeferredCapture
        {
            get
            {
                return _deferred_capture;
            }

            set
            {
                _deferred_capture = value;
            }
        }

        /// <summary>
        /// Payment method settings
        /// </summary> 
        public List<Settings> Settings
        {
            get
            {
                return _settings;
            }

            set
            {
                _settings = value;
            }
        }

        /// <summary>
        /// List of additional information that must be supplied by the payer
        /// </summary> 
        public List<String> AdditionalInfoNeeded
        {
            get
            {
                return _additional_info_needed;
            }

            set
            {
                _additional_info_needed = value;
            }
        }

        /// <summary>
        /// Minimum amount that can be processed with this payment method
        /// </summary> 
        public string MinAllowedAmount
        {
            get
            {
                return _min_allowed_amount;
            }

            set
            {
                _min_allowed_amount = value;
            }
        }

        /// <summary>
        /// Maximum amount that can be processed with this payment method
        /// </summary> 
        public string MaxAllowedAmount
        {
            get
            {
                return _max_allowed_amount;
            }

            set
            {
                _max_allowed_amount = value;
            }
        }

        /// <summary>
        /// How many time in minutes could happen until processing of the payment
        /// </summary> 
        public string AccreditationTime
        {
            get
            {
                return _accreditation_time;
            }

            set
            {
                _accreditation_time = value;
            }
        }

        /// <summary>
        /// Finantial institution processing this payment method
        /// </summary> 
        public List<String> FinancialInstitutions
        {
            get
            {
                return _financial_institutions;
            }

            set
            {
                _financial_institutions = value;
            }
        }

        public List<string> ProcessingMode
        {
            get
            {
                return _processing_mode;
            }

            set
            {
                _processing_mode = value;
            }
        }

        #endregion
    }
}
