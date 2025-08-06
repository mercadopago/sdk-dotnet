namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Counter currency response from Payment.
    /// </summary>
    public class PaymentCounterCurrencyResponse
    {
        /// <summary>
        /// Currency identifier.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Exchange rate.
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Amount refunded.
        /// </summary>
        public decimal? AmountRefunded { get; set; }
    }
} 