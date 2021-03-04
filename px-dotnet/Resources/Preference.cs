using MercadoPago.DataStructures.Preference;
using System;
using System.Collections.Generic;
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
        /// Find a preference trought an unique identifier.
        /// </summary>
        /// <param name="id">Preference ID.</param>
        /// <returns>The preference.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/_checkout_preferences_id/get/">here</a>.
        /// </remarks>
        public static Preference FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Find a preference trought an unique identifier.
        /// </summary>
        /// <param name="id">Preference ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The preference.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/_checkout_preferences_id/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/checkout/preferences/:id")]
        public static Preference FindById(string id, bool useCache, MPRequestOptions requestOptions)
        {            
            return (Preference)ProcessMethod<Preference>(typeof(Preference), "FindById", id, useCache, requestOptions);
        }

        /// <summary>
        /// Save a new preference.
        /// </summary>
        /// <returns><c>true</c> if the preference was saved, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/post/">here</a>.
        /// </remarks>
        public Boolean Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save a new preference.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the preference was saved, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/post/">here</a>.
        /// </remarks>
        [POSTEndpoint("/checkout/preferences")]
        public Boolean Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preference>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        /// <returns><c>true</c> if the preference was updated, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/put/">here</a>.
        /// </remarks>
        public Boolean Update()
        {
            return Update(null);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the preference was updated, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/put/">here</a>.
        /// </remarks>
        [PUTEndpoint("/checkout/preferences/:id")]
        public Boolean Update(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preference>("Update", WITHOUT_CACHE, requestOptions);
        }         
        #endregion

        #region Properties

        private List<Item> _items;
        private List<ProcessingMode> _processing_modes;
        private List<Tax> _taxes;
        private List<Track> _tracks;
        #endregion

        #region Accesors

        /// <summary>
        /// Buyer Information
        /// </summary>
        public Payer? Payer { get; set; }

        /// <summary>
        /// Set up payment methods to be excluded from the payment process
        /// </summary>
        public PaymentMethods? PaymentMethods { get; set; }

        /// <summary>
        /// Shipments information
        /// </summary>
        public Shipment? Shipments { get; set; }

        /// <summary>
        /// URLs to return to the sellers website
        /// </summary>
        public BackUrls? BackUrls { get; set; }

        /// <summary>
        /// URL where you'd like to receive a payment notification
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Preference ID (UUID)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Checkout access URL
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// Sandbox checkout access URL
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Purpose string
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Preference's creation date
        /// </summary>
        public DateTime? Datecreated { get; set; }

        /// <summary>
        /// Operation data_type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType? OperationType { get; set; }

        /// <summary>
        /// Additional information
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// If specified, your buyers will be redirected back to your site immediately after completing the purchase
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AutoReturnType? AutoReturn { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Boolean value that determines if a preference expire
        /// </summary>
        public bool? Expires { get; set; }

        /// <summary>
        /// Date since the preference will be active
        /// </summary>
        public DateTime? ExpirationDateFrom { get; set; }

        /// <summary>
        /// Date when the preference will be expired
        /// </summary>
        public DateTime? ExpirationDateTo { get; set; }

        /// <summary>
        /// When the payment will expires
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Your MercadoPago seller ID
        /// </summary>
        public int? CollectorId { get; set; }

        /// <summary>
        /// Application owner ID that use MercadoLibre API
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Origin of the payment. Default value: NONE
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Marketplace's fee charged by application owner. Default value: 0%
        /// </summary>
        public float? Marketplace_fee { get; set; }

        /// <summary>
        /// Differential pricing configuration for this preference
        /// </summary>
        public DifferentialPricing? Differential_pricing { get; set; }


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
        public long? SponsorId { get; set; }

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
        public bool? BinaryMode { get; set; }

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
        public JObject Metadata { get; set; }

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
