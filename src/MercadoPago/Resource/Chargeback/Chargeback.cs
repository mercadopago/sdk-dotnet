namespace MercadoPago.Resource.Chargeback
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// Chargeback resource.
    /// </summary>
    public class Chargeback : IResource
    {
        /// <summary>
        /// Chargeback ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Payment ID associated with this chargeback.
        /// </summary>
        [JsonProperty("payment_id")]
        public long PaymentId { get; set; }

        /// <summary>
        /// Amount of the chargeback.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency ID of the chargeback.
        /// </summary>
        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// Date when the chargeback was created.
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date when the chargeback was last updated.
        /// </summary>
        [JsonProperty("date_last_updated")]
        public DateTime DateLastUpdated { get; set; }

        /// <summary>
        /// Current status of the chargeback.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Reason for the chargeback.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Metadata associated with the chargeback.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        [JsonIgnore]
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
