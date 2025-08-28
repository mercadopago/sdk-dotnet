namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Payer amounts response within PaymentAmountsResponse.
    /// </summary>
    public class PaymentPayerAmountResponse
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
        /// Total amount paid by payer.
        /// </summary>
        public decimal? TotalPaid { get; set; }
    }
} 