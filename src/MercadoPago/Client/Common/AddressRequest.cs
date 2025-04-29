namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Address information.
    /// </summary>
    public class AddressRequest
    {
        /// <summary>
        /// Zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Number.
        /// </summary>
        public int StreetNumber { get; set; }
    }
}
