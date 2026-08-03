namespace MercadoPago.Client.Payment
{
    using Newtonsoft.Json;

    /// <summary>
    /// Request payload for updating an existing payment.
    /// </summary>
    public class PaymentUpdateRequest
    {
        /// <summary>Gets or sets the new payment status.</summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>Gets or sets whether the payment should be captured.</summary>
        [JsonProperty("capture")]
        public bool? Capture { get; set; }

        /// <summary>Gets or sets the transaction amount.</summary>
        [JsonProperty("transaction_amount")]
        public decimal? TransactionAmount { get; set; }
    }
}
