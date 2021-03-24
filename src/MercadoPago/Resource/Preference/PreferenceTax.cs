namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Tax from <see cref="Preference"/>.
    /// </summary>
    public class PreferenceTax
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
