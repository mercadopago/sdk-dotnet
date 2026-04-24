namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Tax information applied to a payment within a <see cref="PaymentCreateRequest"/>.
    /// Each tax entry specifies a type and monetary value.
    /// </summary>
    public class PaymentTaxRequest
    {
        /// <summary>
        /// Type of tax being applied (e.g., "IVA", "ISC").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Monetary value of the tax.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
