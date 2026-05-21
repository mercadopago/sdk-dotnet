namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the shipping destination address for a <see cref="MerchantOrderShipment"/>.
    /// Contains the full address details including street, city, state, country, and geolocation coordinates.
    /// </summary>
    public class MerchantOrderReceiverAddress
    {
        /// <summary>
        /// Unique identifier of the receiver address in MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Full address line combining street name and number (e.g., "Av. Corrientes 1234").
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Apartment number or identifier within the building.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// City where the shipment will be delivered.
        /// </summary>
        public MerchantOrderReceiverAddressCity City { get; set; }

        /// <summary>
        /// State or province where the shipment will be delivered.
        /// </summary>
        public MerchantOrderReceiverAddressState State { get; set; }

        /// <summary>
        /// Country where the shipment will be delivered.
        /// </summary>
        public MerchantOrderReceiverAddressCountry Country { get; set; }

        /// <summary>
        /// Additional delivery instructions or comments about the address (e.g., "Ring bell twice").
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Name of the contact person at the delivery address.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Postal or ZIP code of the delivery address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Name of the street at the delivery address.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number at the delivery address.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Contact phone number at the delivery address.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Geographic latitude coordinate of the delivery address for mapping purposes.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Geographic longitude coordinate of the delivery address for mapping purposes.
        /// </summary>
        public string Longitude { get; set; }
    }
}
