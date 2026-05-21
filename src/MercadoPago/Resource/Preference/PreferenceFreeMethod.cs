namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents a shipping method offered as free shipping within <see cref="PreferenceShipments"/>.
    /// Only applicable when the shipping mode is set to <c>me2</c> (MercadoEnvios).
    /// </summary>
    public class PreferenceFreeMethod
    {
        /// <summary>
        /// Identifier of the shipping method to be offered as free.
        /// </summary>
        public long? Id { get; set; }
    }
}
