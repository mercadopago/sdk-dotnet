namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Simplified default address data returned inline on a
    /// <see cref="Customer"/> resource. For the full address details (city,
    /// state, country), see the <see cref="Customer.Addresses"/> collection.
    /// </summary>
    public class CustomerDefaultAddress
    {
        /// <summary>
        /// Unique identifier of this address within the customer's address list.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Postal / ZIP code of the address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name component of the address.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number (house or building number) of the address.
        /// </summary>
        public int? StreetNumber { get; set; }
    }
}
