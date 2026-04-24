// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents a physical address used in payer or shipment information within a payment order.
    /// </summary>
    /// <seealso cref="OrderPayerRequest"/>
    /// <seealso cref="OrderShipmentRequest"/>
    public class OrderAddressRequest
    {
        /// <summary>
        /// Street name of the address (e.g., "Av. Corrientes").
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number or house number of the address.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Postal or ZIP code of the address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Neighborhood or district name.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// State or province name.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Additional address details such as apartment or suite number.
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        /// Floor number within a building, if applicable.
        /// </summary>
        public string Floor { get; set; }
    }
}
