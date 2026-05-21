namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Counter-currency conversion details for cross-border payments where
    /// the payer's currency differs from the collector's currency.
    /// </summary>
    public class PaymentCounterCurrencyResponse
    {
        /// <summary>
        /// ISO 4217 currency code of the counter currency (e.g., "USD", "BRL").
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Exchange rate applied to convert from the payment currency to the
        /// counter currency at the time of the transaction.
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Payment amount expressed in the counter currency after applying
        /// the exchange rate.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Total refunded amount expressed in the counter currency.
        /// </summary>
        public decimal? AmountRefunded { get; set; }
    }
} 