namespace MercadoPago.Resources
{
    /// <summary>
    /// This class allows to use the "users" API to obtain user information.
    /// </summary>
    public class User : MPBase
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
        /// User country ID
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Returns configured user information
        /// </summary>
        /// <returns>User information</returns>
        public static User Find()
        {
            return Find(false, null);
        }

        /// <summary>
        /// Returns configured user information
        /// </summary>
        /// <param name="useCache">Use local cache or not</param>
        /// <returns>User information</returns>
        public static User Find(bool useCache)
        {
            return Find(useCache, null);
        }

        /// <summary>
        /// Returns configured user information
        /// </summary>
        /// <param name="requestOptions">Request options</param>
        /// <returns>User information</returns>
        public static User Find(MPRequestOptions requestOptions)
        {
            return Find(false, requestOptions);
        }

        /// <summary>
        /// Returns configured user information
        /// </summary>
        /// <param name="useCache">Use local cache or not</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>User information</returns>
        [GETEndpoint("/users/me")]
        public static User Find(bool useCache, MPRequestOptions requestOptions)
        {
            return (User)ProcessMethod<User>("Find", null, useCache, requestOptions);
        }
    }
}
