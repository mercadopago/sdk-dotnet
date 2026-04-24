namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Amount information from the collector's (seller's) perspective
    /// within the <see cref="PaymentAmountsResponse"/>.
    /// </summary>
    public class PaymentCollectorAmountResponse
    {
        /// <summary>
        /// ISO 4217 currency code for the collector's amounts (e.g., "ARS", "BRL", "MXN").
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Total transaction amount in the collector's currency.
        /// </summary>
        public decimal? Transaction { get; set; }

        /// <summary>
        /// Net amount received by the collector after deducting
        /// all applicable fees and commissions.
        /// </summary>
        public decimal? NetReceived { get; set; }
    }
} 