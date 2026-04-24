namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Reusable address DTO shared across multiple API request types such as
    /// payment payer addresses and customer addresses.
    /// </summary>
    public class AddressRequest
    {
        /// <summary>
        /// Postal / ZIP code of the address (e.g., <c>"01310-100"</c> for Brazil).
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street or avenue name (e.g., <c>"Av. Paulista"</c>).
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number or building identifier of the address.
        /// </summary>
        public int StreetNumber { get; set; }
    }
}
