namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Delivery address
    /// </summary>
    public class ReceiverAddress
    {
        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Floor
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment
        /// </summary>
        public string Apartment { get; set; }
    }
}
