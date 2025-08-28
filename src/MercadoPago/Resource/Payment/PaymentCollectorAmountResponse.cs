namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Collector amounts response within PaymentAmountsResponse.
    /// </summary>
    public class PaymentCollectorAmountResponse
    {
        /// <summary>
        /// Currency identifier.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        public decimal? Transaction { get; set; }

        /// <summary>
        /// Net amount received by collector.
        /// </summary>
        public decimal? NetReceived { get; set; }
    }
} 