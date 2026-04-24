namespace MercadoPago.Client.Customer
{
    /// <summary>
    /// Request DTO representing a customer's default shipping/billing address.
    /// Used within <see cref="CustomerRequest.Address"/> when creating or updating a customer profile.
    /// </summary>
    public class CustomerDefaultAddressRequest
    {
        /// <summary>
        /// Existing address identifier. When updating an address, set this to the ID
        /// of the address record to modify; leave <c>null</c> for new addresses.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Postal / ZIP code of the address (e.g., <c>"01310-100"</c> for Brazil).
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street or avenue name (e.g., <c>"Av. Paulista"</c>).
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number or building identifier. Nullable to allow partial updates.
        /// </summary>
        public int? StreetNumber { get; set; }
    }
}
