// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

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

        /// <summary>
        /// Neighborhood.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Complement.
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor { get; set; }
    }
}
