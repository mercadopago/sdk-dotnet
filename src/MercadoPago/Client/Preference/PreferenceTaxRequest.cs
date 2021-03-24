namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Tax information.
    /// </summary>
    public class PreferenceTaxRequest
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
