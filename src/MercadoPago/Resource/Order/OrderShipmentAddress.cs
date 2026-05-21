// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the physical delivery address for an <see cref="OrderShipment"/>, including street,
    /// city, state, and postal code details.
    /// </summary>
    public class OrderShipmentAddress
    {
        /// <summary>
        /// Name of the street or avenue for the delivery address.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number or house number at the delivery address.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Postal or ZIP code for the delivery address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Neighborhood or district name within the city.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// City name for the delivery address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State or province name for the delivery address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Additional address details such as apartment number, floor, or building name.
        /// </summary>
        public string Complement { get; set; }
    }
}
