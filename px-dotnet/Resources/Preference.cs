using MercadoPago.DataStructures.Preference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace MercadoPago.Resources
{
    /// <summary>
    /// This API allows you to set up, during the payment process, 
    /// all the item information, any accepted means of payment and many other options.
    /// </summary>
    public class Preference : MPBase
    {
        #region Actions
        /// <summary>
        /// Find a preference trought an unique identifier
        /// </summary>
        public static Preference FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE);
        }
        /// <summary>
        /// Find a preference trought an unique identifier with Local Cache Flag
        /// </summary>
        [GETEndpoint("/checkout/preferences/:id")]
        public static Preference FindById(string id, bool useCache)
        {            
            return (Preference)ProcessMethod<Preference>(typeof(Preference), "FindById", id, useCache);
        } 
        /// <summary>
        /// Save a new preference
        /// </summary>
        [POSTEndpoint("/checkout/preferences")]
        public Preference Save()
        {
            return (Preference)ProcessMethod<Preference>("Save", WITHOUT_CACHE);
        } 
        /// <summary>
        ///  Update editable properties
        /// </summary>
        [PUTEndpoint("/checkout/preferences/:id")]
        public Preference Update()
        {
            return (Preference)ProcessMethod<Preference>("Update", WITHOUT_CACHE);
        }         
        #endregion

        #region Properties
        private List<Item> _items = new List<Item>();
        private Payer? _payer;
        private PaymentMethods? _payment_methods;
        private Shipment? _shipment;
        private BackUrls? _back_urls;
        [StringLength(500)]
        private string _notification_url;
        private string _id;
        private string _init_point;
        private string _sandbox_init_point;
        private DateTime? _date_created;
        [JsonConverter(typeof(StringEnumConverter))]
        private OperationType? _operation_type; 
        [StringLength(600)]
        private string _additionalInfo;
        [JsonConverter(typeof(StringEnumConverter))]
        private AutoReturnType? _auto_return;
        [StringLength(256)]
        private string _external_reference;
        private bool? _expires;
        private DateTime? _expiration_date_from;
        private DateTime? _expiration_dateTo;
        private int? _collector_id;
        private string _client_id; 
        [StringLength(256)]
        private string _marketplace;  
        private decimal? _marketplace_fee;
        private DifferentialPricing? _differential_pricing; 
        #endregion

        #region Accesors
        /// <summary>
        /// Items information
        /// </summary>
        public List<Item> Items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }
        /// <summary>
        /// Buyer Information
        /// </summary>
        public Payer? Payer 
        {
            get
            {
                return _payer;
            }

            set
            {
                _payer = value;
            }
        }
        /// <summary>
        /// Set up payment methods to be excluded from the payment process
        /// </summary>
        public PaymentMethods? PaymentMethods
        {
            get
            {
                return _payment_methods;
            }

            set
            {
                _payment_methods = value;
            }
        }
        /// <summary>
        /// Shipments information
        /// </summary>
        public Shipment? Shipment 
        {
            get
            {
                return _shipment;
            }

            set
            {
                _shipment = value;
            }
        }
        /// <summary>
        /// URLs to return to the sellers website
        /// </summary>
        public BackUrls? BackUrls
        {
            get
            {
                return _back_urls;
            }

            set
            {
                _back_urls = value;
            }
        }
        /// <summary>
        /// URL where you'd like to receive a payment notification
        /// </summary>
        public string NotificationUrl
        {
            get
            {
                return _notification_url;
            }

            set
            {
                _notification_url = value;
            }
        }
        /// <summary>
        /// Preference ID (UUID)
        /// </summary>
        public string Id 
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        /// <summary>
        /// Checkout access URL
        /// </summary>
        public string InitPoint 
        {
            get
            {
                return _init_point;
            }

            private set
            {
                _init_point = value;
            }
        }
        /// <summary>
        /// Sandbox checkout access URL
        /// </summary>
        public string SandboxInitPoint
        {
            get
            {
                return _sandbox_init_point;
            }

            set
            {
                _sandbox_init_point = value;
            }
        }
        /// <summary>
        /// Preference's creation date
        /// </summary>
        public DateTime? Datecreated
        {
            get
            {
                return _date_created;
            }

            set
            {
                _date_created = value;
            }
        }
        /// <summary>
        /// Operation data_type
        /// </summary>
        public OperationType? OperationType
        {
            get
            {
                return _operation_type;
            }

            set
            {
                _operation_type = value;
            }
        }
        /// <summary>
        /// Additional information
        /// </summary>
        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }

            set
            {
                _additionalInfo = value;
            }
        }
        /// <summary>
        /// If specified, your buyers will be redirected back to your site immediately after completing the purchase
        /// </summary>
        public AutoReturnType? AutoReturn 
        {
            get
            {
                return _auto_return;
            }

            set
            {
                _auto_return = value;
            }
        }
        /// <summary>
        /// Reference you can synchronize with your payment system
        /// </summary>
        public string ExternalReference 
        {
            get
            {
                return _external_reference;
            }

            set
            {
                _external_reference = value;
            }
        }
        /// <summary>
        /// Boolean value that determines if a preference expire
        /// </summary>
        public bool? Expires 
        {
            get
            {
                return _expires;
            }

            set
            {
                _expires = value;
            }
        }
        /// <summary>
        /// Date since the preference will be active
        /// </summary>
        public DateTime? ExpirationDateFrom 
        {
            get
            {
                return _expiration_date_from;
            }

            set
            {
                _expiration_date_from = value;
            }
        }
        /// <summary>
        /// Date when the preference will be expired
        /// </summary>
        public DateTime? ExpirationDateTo 
        {
            get
            {
                return _expiration_dateTo;
            }

            set
            {
                _expiration_dateTo = value;
            }
        }
        /// <summary>
        /// Your MercadoPago seller ID
        /// </summary>
        public int? CollectorId 
        {
            get
            {
                return _collector_id;
            }

            set
            {
                _collector_id = value;
            }
        }
        /// <summary>
        /// Application owner ID that use MercadoLibre API
        /// </summary>
        public string ClientId 
        {
            get
            {
                return _client_id;
            }

            set
            {
                _client_id = value;
            }
        }
        /// <summary>
        /// Origin of the payment. Default value: NONE
        /// </summary>
        public string Marketplace 
        {
            get
            {
                return _marketplace;
            }

            set
            {
                _marketplace = value;
            }
        }
        /// <summary>
        /// Marketplace's fee charged by application owner. Default value: 0%
        /// </summary>
        public decimal? Marketplace_fee 
        {
            get
            {
                return _marketplace_fee;
            }

            set
            {
                _marketplace_fee = value;
            }
        }
        /// <summary>
        /// Differential pricing configuration for this preference
        /// </summary>
        public DifferentialPricing? Differential_pricing 
        {
            get
            {
                return _differential_pricing;
            }

            set
            {
                _differential_pricing = value;
            }
        }
         
        #endregion
    }
}
