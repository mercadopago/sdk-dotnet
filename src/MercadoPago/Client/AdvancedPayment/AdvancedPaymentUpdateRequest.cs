namespace MercadoPago.Client.AdvancedPayment
{
    using Newtonsoft.Json;

    /// <summary>
    /// Request body for updating an advanced payment via
    /// <see cref="AdvancedPaymentClient.UpdateAsync"/> / <see cref="AdvancedPaymentClient.Update"/>.
    /// </summary>
    public class AdvancedPaymentUpdateRequest
    {
        /// <summary>
        /// Set to <c>true</c> to capture a previously authorized advanced payment.
        /// </summary>
        [JsonProperty("capture")]
        public bool? Capture { get; set; }

        /// <summary>
        /// New status for the advanced payment (e.g. <c>cancelled</c>).
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
