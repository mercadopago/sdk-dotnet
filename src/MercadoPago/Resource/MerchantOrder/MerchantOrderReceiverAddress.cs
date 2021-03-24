namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Shipping address of a Merchant Order.
    /// </summary>
    public class MerchantOrderReceiverAddress
    {
        /// <summary>
        /// Receiver address ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Street name and number of receiver address.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Apartment.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// City information.
        /// </summary>
        public MerchantOrderReceiverAddressCity City { get; set; }

        /// <summary>
        /// State information.
        /// </summary>
        public MerchantOrderReceiverAddressState State { get; set; }

        /// <summary>
        /// Country information.
        /// </summary>
        public MerchantOrderReceiverAddressCountry Country { get; set; }

        /// <summary>
        /// Comment about receiver address.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Contact information.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Latitude.
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        public string Longitude { get; set; }
    }
}
