namespace MercadoPago.Resource.Preference
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Preference resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/resource/">here</a>.
    /// </remarks>
    public class Preference : IResource
    {
        /// <summary>
        /// Preference ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// List of items to be paid.
        /// </summary>
        public IList<PreferenceItem> Items { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public PreferencePayer Payer { get; set; }

        /// <summary>
        /// Set up payment methods.
        /// </summary>
        public PreferencePaymentMethods PaymentMethods { get; set; }

        /// <summary>
        /// URLs to return to the sellers website.
        /// </summary>
        public PreferenceBackUrls BackUrls { get; set; }

        /// <summary>
        /// Shipments information.
        /// </summary>
        public PreferenceShipments Shipments { get; set; }

        /// <summary>
        /// URL where you'd like to receive a payment notification.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// How will look the payment in the card bill (e.g.: MERCADOPAGO).
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// <c>true</c> if a preference expire, <c>false</c> if not.
        /// </summary>
        public bool? Expires { get; set; }

        /// <summary>
        /// Expiration date of cash payment.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Date since the preference will be active.
        /// </summary>
        public DateTime? ExpirationDateFrom { get; set; }

        /// <summary>
        /// Date when the preference will be expired.
        /// </summary>
        public DateTime? ExpirationDateTo { get; set; }

        /// <summary>
        /// Collector ID.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Origin of the payment. Default value: NONE.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Marketplace's fee charged by application owner.
        /// </summary>
        public decimal? MarketplaceFee { get; set; }

        /// <summary>
        /// Purpose of the Preference.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Additional info.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// If specified, your buyers will be redirected back to your site
        /// immediately after completing the purchase.
        /// </summary>
        public string AutoReturn { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Differential pricing configuration for this preference.
        /// </summary>
        public PreferenceDifferentialPricing DifferentialPricing { get; set; }

        /// <summary>
        /// Sponsor Id.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Configures which processing modes to use.
        /// </summary>
        public IList<string> ProcessingModes { get; set; }

        /// <summary>
        /// When set to true, the payment can only be approved or rejected.
        /// Otherwise in_process status is added.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Taxes for preferences.
        /// </summary>
        public IList<PreferenceTax> Taxes { get; set; }

        /// <summary>
        /// Tracks to be executed during the users's interaction in the Checkout flow.
        /// </summary>
        public IList<PreferenceTrack> Tracks { get; set; }

        /// <summary>
        /// Data that can be attached to the preference to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Checkout URL from preference.
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// Sandbox checkout URL from preference.
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
