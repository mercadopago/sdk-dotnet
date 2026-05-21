namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Represents a tax applied to an <see cref="AdvancedPaymentSplitPayment"/>.
    /// Contains the tax classification and the monetary amount.
    /// </summary>
    public class AdvancedPaymentTax
    {
        /// <summary>
        /// Tax type identifier (e.g., <c>IVA</c>, <c>ISC</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Monetary value of the tax, in the transaction currency.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
