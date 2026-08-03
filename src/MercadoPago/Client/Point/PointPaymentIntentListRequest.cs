namespace MercadoPago.Client.Point
{
    using Newtonsoft.Json;

    /// <summary>
    /// Query parameters for listing payment intent events
    /// via <see cref="PointClient.GetPaymentIntentListAsync"/> /
    /// <see cref="PointClient.GetPaymentIntentList"/>.
    /// </summary>
    public class PointPaymentIntentListRequest
    {
        /// <summary>
        /// Start of the date range for filtering events (ISO 8601 format).
        /// Sent as the <c>startDate</c> query parameter.
        /// </summary>
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// End of the date range for filtering events (ISO 8601 format).
        /// Sent as the <c>endDate</c> query parameter.
        /// </summary>
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
    }
}
