using MercadoPago.DataStructures.Preference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Find a preference trought an unique identifier with Local Cache Flag
        /// </summary>
        [GETEndpoint("/checkout/preferences/:id")]
        public static Preference FindById(string id, bool useCache, MPRequestOptions requestOptions)
        {            
            return (Preference)ProcessMethod<Preference>(typeof(Preference), "FindById", id, useCache, requestOptions);
        }

        /// <summary>
        /// Save a new preference
        /// </summary>
        public Boolean Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save a new preference
        /// </summary>
        [POSTEndpoint("/checkout/preferences")]
        public Boolean Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preference>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        public Boolean Update()
        {
            return Update(null);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        [PUTEndpoint("/checkout/preferences/:id")]
        public Boolean Update(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preference>("Update", WITHOUT_CACHE, requestOptions);
        }         
        #endregion

        #region Properties

        private List<Item> _items;
        private Payer? _payer;
        private PaymentMethods? _payment_methods;
        private Shipment? _shipments;
        private BackUrls? _back_urls;
        [StringLength(500)]
        private string _notification_url;
        private string _id;
        private string _init_point;
        private string _sandbox_init_point;
        private string _purpose;
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
        private float? _marketplace_fee;
        private DifferentialPricing? _differential_pricing;
        private long? _sponsor_id;
        private List<ProcessingMode> _processing_modes;
        private bool? _binary_mode;
        private List<Tax> _taxes;
        private JObject _metadata;
        private List<Track> _tracks;
        #endregion

        #region Accesors

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
        public Shipment? Shipments
        {
            get
            {
                return _shipments;
            }

            set
            {
                _shipments = value;
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
        /// Purpose string
        /// </summary>
        public string Purpose
        {
            get
            {
                return _purpose;
            }

            set
            {
                _purpose = value;
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
        public float? Marketplace_fee 
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

        /// <summary>
        /// Purchased items
        /// </summary>
        public List<Item> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<Item>();
                }
                return _items;
            }

            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Sponsor ID
        /// </summary>
        public long? SponsorId
        {
            get
            {
                return _sponsor_id;
            }

            set
            {
                _sponsor_id = value;
            }
        }

        /// <summary>
        /// Processing modes
        /// </summary>
        public List<ProcessingMode> ProcessingModes
        {
            get
            {
                if (_processing_modes == null)
                {
                    _processing_modes = new List<ProcessingMode>();
                }
                return _processing_modes;
            }

            set
            {
                _processing_modes = value;
            }
        }

        /// <summary>
        /// Binary mode?
        /// </summary>
        public bool? BinaryMode
        {
            get
            {
                return _binary_mode;
            }

            set
            {
                _binary_mode = value;
            }
        }

        /// <summary>
        /// Taxes
        /// </summary>
        public List<Tax> Taxes
        {
            get
            {
                if (_taxes == null)
                {
                    _taxes = new List<Tax>();
                }
                return _taxes;
            }

            set
            {
                _taxes = value;
            }
        }

        /// <summary>
        /// Valid JSON that can be attached to the payment to record additional attributes of the merchant
        /// </summary>
        public JObject Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        /// <summary>
        /// Preference ad tracks
        /// </summary>
        public List<Track> Tracks
        {
            get
            {
                if (_tracks == null)
                {
                    _tracks = new List<Track>();
                }
                return _tracks;
            }

            set { _tracks = value; }
        }
        #endregion
    }
}
