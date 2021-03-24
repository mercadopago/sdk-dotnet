namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Default address's information.
    /// </summary>
    public class CustomerDefaultAddress
    {
        /// <summary>
        /// Address ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number.
        /// </summary>
        public int? StreetNumber { get; set; }
    }
}
