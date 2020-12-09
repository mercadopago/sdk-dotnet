namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Tax.
    /// </summary>
    public class PaymentTaxRequest
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
