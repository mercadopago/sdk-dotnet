namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Amount information from the payer's (buyer's) perspective
    /// within the <see cref="PaymentAmountsResponse"/>.
    /// </summary>
    public class PaymentPayerAmountResponse
    {
        /// <summary>
        /// ISO 4217 currency code for the payer's amounts (e.g., "ARS", "BRL", "MXN").
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Base transaction amount in the payer's currency, before any
        /// additional fees or financing costs.
        /// </summary>
        public decimal? Transaction { get; set; }

        /// <summary>
        /// Total amount actually paid by the payer, including any
        /// financing fees, taxes, or surcharges.
        /// </summary>
        public decimal? TotalPaid { get; set; }
    }
} 