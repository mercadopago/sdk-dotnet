namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Shipping destination address for a merchant order shipment.
    /// Contains the full delivery location including geographic coordinates.
    /// </summary>
    /// <see cref="MerchantOrderShipmentRequest"/>
    public class MerchantOrderReceiverAddressRequest
    {
        /// <summary>
        /// Unique identifier of the receiver address in MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Full address line containing the street name and number (e.g., <c>"Calle Falsa 123"</c>).
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Apartment, suite, or unit number within the building.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// City where the shipment will be delivered.
        /// </summary>
        /// <see cref="MerchantOrderReceiverAddressCityRequest"/>
        public MerchantOrderReceiverAddressCityRequest City { get; set; }

        /// <summary>
        /// State or province where the shipment will be delivered.
        /// </summary>
        /// <see cref="MerchantOrderReceiverAddressStateRequest"/>
        public MerchantOrderReceiverAddressStateRequest State { get; set; }

        /// <summary>
        /// Country where the shipment will be delivered.
        /// </summary>
        /// <see cref="MerchantOrderReceiverAddressCountryRequest"/>
        public MerchantOrderReceiverAddressCountryRequest Country { get; set; }

        /// <summary>
        /// Additional delivery instructions or comments for the carrier.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Name or phone number of the contact person at the delivery address.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Postal or ZIP code of the receiver address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name component of the address (without house number).
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// House or building number on the street.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Phone number of the shipment receiver, including area code.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Geographic latitude of the delivery address in decimal degrees.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Geographic longitude of the delivery address in decimal degrees.
        /// </summary>
        public string Longitude { get; set; }
    }
}
