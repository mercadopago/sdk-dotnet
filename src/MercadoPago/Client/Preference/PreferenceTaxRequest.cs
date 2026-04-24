namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Tax applied to a Checkout Pro preference. Multiple taxes can be added to a
    /// <see cref="PreferenceRequest"/> (e.g., VAT and IVA).
    /// </summary>
    public class PreferenceTaxRequest
    {
        /// <summary>
        /// Tax type identifier (e.g., <c>"IVA"</c>, <c>"VAT"</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tax amount to apply to the preference total.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
