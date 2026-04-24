namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents a tax applied to a <see cref="Preference"/>.
    /// Contains the tax classification and the monetary amount to be charged.
    /// </summary>
    public class PreferenceTax
    {
        /// <summary>
        /// Tax type identifier (e.g., <c>IVA</c>, <c>ISC</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Monetary value of the tax, in the preference currency.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
