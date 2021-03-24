using MercadoPago.Http;

namespace MercadoPago.Resource.User
{
    /// <summary>
    /// Class with User information.
    /// </summary>
    public class User : IResource
    {
        /// <summary>
        /// User ID
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// User nickname
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Site ID.
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// User country ID
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
