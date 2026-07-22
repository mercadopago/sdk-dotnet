// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using Newtonsoft.Json;

    /// <summary>
    /// Typed additional information attached to an <see cref="OrderCreateRequest"/> to improve
    /// fraud analysis and risk scoring. Fields use dotted-notation JSON keys as required by the
    /// Orders API (<c>POST /v1/orders</c>).
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    public class OrderAdditionalInfoRequest
    {
        /// <summary>
        /// Authentication method used by the payer on the merchant's site
        /// (e.g., <c>"Gmail"</c>, <c>"Facebook"</c>, <c>"Native"</c>).
        /// </summary>
        [JsonProperty("payer.authentication_type")]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Date when the payer registered on the merchant's site, in ISO 8601 format.
        /// Used for fraud risk assessment based on account age.
        /// </summary>
        [JsonProperty("payer.registration_date")]
        public string RegistrationDate { get; set; }

        /// <summary>
        /// <c>true</c> if the payer is a premium or prime user on the merchant's platform;
        /// otherwise, <c>false</c>.
        /// </summary>
        [JsonProperty("payer.is_prime_user")]
        public bool? IsPrimeUser { get; set; }

        /// <summary>
        /// <c>true</c> if this is the payer's first online purchase on the merchant's platform;
        /// otherwise, <c>false</c>.
        /// </summary>
        [JsonProperty("payer.is_first_purchase_online")]
        public bool? IsFirstPurchaseOnline { get; set; }

        /// <summary>
        /// Date and time of the payer's most recent purchase on the merchant's platform,
        /// in ISO 8601 format.
        /// </summary>
        [JsonProperty("payer.last_purchase")]
        public string LastPurchase { get; set; }

        /// <summary>
        /// <c>true</c> if the shipment should be delivered via an express (same-day or next-day) method;
        /// otherwise, <c>false</c>.
        /// </summary>
        [JsonProperty("shipment.express")]
        public bool? Express { get; set; }

        /// <summary>
        /// <c>true</c> if the buyer will collect the order at a physical location (click &amp; collect);
        /// otherwise, <c>false</c>.
        /// </summary>
        [JsonProperty("shipment.local_pickup")]
        public bool? LocalPickup { get; set; }
    }
}
