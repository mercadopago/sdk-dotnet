namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// State or province component of a <see cref="CustomerAddress"/>. The
    /// identifier and name correspond to MercadoPago's geographic catalog.
    /// </summary>
    public class CustomerAddressState
    {
        /// <summary>
        /// MercadoPago internal identifier for the state or province.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the state or province.
        /// </summary>
        public string Name { get; set; }
    }
}
