namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Neighborhood (barrio) component of a <see cref="CustomerAddress"/>.
    /// The identifier and name correspond to MercadoPago's geographic catalog.
    /// </summary>
    public class CustomerAddressNeighborhood
    {
        /// <summary>
        /// MercadoPago internal identifier for the neighborhood.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the neighborhood.
        /// </summary>
        public string Name { get; set; }
    }
}
