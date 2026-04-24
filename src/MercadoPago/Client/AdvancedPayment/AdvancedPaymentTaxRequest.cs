namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Represents a tax charge applied to a split payment within an advanced payment.
    /// </summary>
    /// <see cref="AdvancedPaymentSplitPaymentRequest"/>
    public class AdvancedPaymentTaxRequest
    {
        /// <summary>
        /// Tax type identifier (e.g., <c>"IVA"</c>, <c>"IVA 10.5"</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tax amount in the payment currency. Must be zero or greater.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
