using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;
using MercadoPago.DataStructures.Preference;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Resources
{
    public sealed class Preference: Resource<Preference>
    {
        #region Actions
        
        /// <summary>
        /// Find a preference through an unique identifier with Local Cache Flag
        /// </summary>
        public static Preference FindById(string id, bool useCache = false) => 
            Get($"/checkout/preferences/{id}", useCache);

        /// <summary>
        /// Save a new preference
        /// </summary>
        public Preference Save() => Post($"/checkout/preferences");

        /// <summary>
        ///  Update editable properties
        /// </summary>
        public Preference Update() => Put($"/checkout/preferences/{Id}");
        
        #endregion

        #region Properties
        /// <summary>
        /// Items information
        /// </summary>
        public List<Item> Items { get; set; } = new List<Item>();

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
        public Shipment? Shipment { get; set; }

        /// <summary>
        /// URLs to return to the sellers website
        /// </summary>
        public BackUrls? BackUrls { get; set; }

        /// <summary>
        /// URL where you'd like to receive a payment notification
        /// </summary>
        [StringLength(500)]
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Preference ID (UUID)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Checkout access URL
        /// </summary>
        public string InitPoint { get; private set; }

        /// <summary>
        /// Sandbox checkout access URL
        /// </summary>
        public string SandboxInitPoint { get; set; }

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
        [StringLength(600)]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// If specified, your buyers will be redirected back to your site immediately after completing the purchase
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AutoReturnType? AutoReturn { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system
        /// </summary>
        [StringLength(256)]
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
        [StringLength(256)]
        public string Marketplace { get; set; }

        /// <summary>
        /// Marketplace's fee charged by application owner. Default value: 0%
        /// </summary>
        public decimal? Marketplace_fee { get; set; }

        /// <summary>
        /// Differential pricing configuration for this preference
        /// </summary>
        public DifferentialPricing? Differential_pricing { get; set; }

        #endregion
    }
}
