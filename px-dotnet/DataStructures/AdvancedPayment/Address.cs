namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Payer address
    /// </summary>
    public class Address
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
    }
}
