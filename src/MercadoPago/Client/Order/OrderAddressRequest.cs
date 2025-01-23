namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Address class.
    /// </summary>
    public class OrderAddressRequest
    {

        /// <summary>
        /// Street Name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street Number.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Zip Code.
        /// </summary>
        public string ZipCode { get; set; }
    }

}