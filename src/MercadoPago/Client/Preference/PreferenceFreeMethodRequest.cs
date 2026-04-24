namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Identifies a shipping method to offer as free shipping in a MercadoEnvios (<c>"me2"</c>) preference.
    /// Used within <see cref="PreferenceShipmentsRequest.FreeMethods"/>.
    /// </summary>
    public class PreferenceFreeMethodRequest
    {
        /// <summary>
        /// Numeric ID of the MercadoEnvios shipping method to offer as free shipping.
        /// </summary>
        public long? Id { get; set; }
    }
}
