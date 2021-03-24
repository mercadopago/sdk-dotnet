namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Tax.
    /// </summary>
    public class AdvancedPaymentTax
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
