namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the differential pricing configuration for a <see cref="Preference"/>,
    /// allowing merchants to offer different prices to specific buyer segments or groups.
    /// </summary>
    public class PreferenceDifferentialPricing
    {
        /// <summary>
        /// Identifier of the differential pricing rule configured in the MercadoPago platform.
        /// </summary>
        public long? Id { get; set; }
    }
}
