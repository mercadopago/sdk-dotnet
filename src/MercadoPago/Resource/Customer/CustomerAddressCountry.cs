namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Country component of a <see cref="CustomerAddress"/>. The identifier
    /// follows the ISO 3166-1 standard used by MercadoPago.
    /// </summary>
    public class CustomerAddressCountry
    {
        /// <summary>
        /// Country identifier (e.g. <c>AR</c>, <c>BR</c>, <c>MX</c>).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the country.
        /// </summary>
        public string Name { get; set; }
    }
}
