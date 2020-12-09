namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Tax.
    /// </summary>
    public class PaymentTax
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
