namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// User amounts request within PaymentAmountsRequest.
    /// </summary>
    public class PaymentUserAmountsRequest
    {
        /// <summary>
        /// Currency identifier.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        public decimal? Transaction { get; set; }
    }
} 