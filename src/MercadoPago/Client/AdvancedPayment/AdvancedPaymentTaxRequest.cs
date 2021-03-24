namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Tax.
    /// </summary>
    public class AdvancedPaymentTaxRequest
    {
        /// <summary>
        /// Tax type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tax value.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
