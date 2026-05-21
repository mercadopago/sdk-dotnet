namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Municipality (municipio) component of a <see cref="CustomerAddress"/>.
    /// Used in countries where municipality is a distinct administrative
    /// division (e.g. Brazil, Colombia).
    /// </summary>
    public class CustomerAddressMunicipality
    {
        /// <summary>
        /// MercadoPago internal identifier for the municipality.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the municipality.
        /// </summary>
        public string Name { get; set; }
    }
}
