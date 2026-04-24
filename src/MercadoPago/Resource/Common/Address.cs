namespace MercadoPago.Resource.Common
{
    /// <summary>
    /// Shared address data that appears in multiple MercadoPago API responses
    /// (payments, preferences, merchant orders, etc.). Contains the minimal
    /// set of fields common to all address representations in the API.
    /// </summary>
    public class Address
    {
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
        public string StreetNumber { get; set; }
    }
}
