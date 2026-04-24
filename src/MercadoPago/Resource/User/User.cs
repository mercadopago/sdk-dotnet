using MercadoPago.Http;

namespace MercadoPago.Resource.User
{
    /// <summary>
    /// Represents the authenticated MercadoPago user (account) returned by
    /// the Users API. Contains basic profile data such as name, email, and
    /// locale. Use <see cref="Client.User.UserClient"/> to retrieve the
    /// current user's information.
    /// </summary>
    public class User : IResource
    {
        /// <summary>
        /// Unique MercadoPago user identifier.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Public nickname of the user within the MercadoPago/MercadoLibre
        /// platform.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// User's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name (surname).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's email address registered in MercadoPago.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// MercadoPago site identifier that indicates the country-specific
        /// marketplace (e.g. <c>MLA</c> for Argentina, <c>MLB</c> for
        /// Brazil, <c>MLM</c> for Mexico).
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// ISO 3166-1 country identifier of the user's account (e.g.
        /// <c>AR</c>, <c>BR</c>, <c>MX</c>).
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
