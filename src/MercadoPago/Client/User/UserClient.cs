namespace MercadoPago.Client.User
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.User;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client to get the User information.
    /// </summary>
    public class UserClient : MercadoPagoClient<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public UserClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public UserClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public UserClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        public UserClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Get async the User information using the Access Token.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the User.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public Task<User> GetAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/users/me",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Get the User information using the Access Token.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The User.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        public User Get(
            RequestOptions requestOptions = null)
        {
            return Send(
                "/users/me",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
