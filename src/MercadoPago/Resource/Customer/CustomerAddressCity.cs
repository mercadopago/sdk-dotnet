namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// City component of a <see cref="CustomerAddress"/>. The identifier and
    /// name correspond to MercadoPago's geographic catalog.
    /// </summary>
    public class CustomerAddressCity
    {
        /// <summary>
        /// MercadoPago internal identifier for the city.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the city.
        /// </summary>
        public string Name { get; set; }
    }
}
