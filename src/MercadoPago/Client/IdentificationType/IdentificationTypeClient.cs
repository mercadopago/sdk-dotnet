namespace MercadoPago.Client.IdentificationType
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.IdentificationType;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client with methods of Identification Type APIs.
    /// </summary>
    public class IdentificationTypeClient : MercadoPagoClient<IdentificationType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationTypeClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public IdentificationTypeClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationTypeClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public IdentificationTypeClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationTypeClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public IdentificationTypeClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentificationTypeClient"/> class.
        /// </summary>
        public IdentificationTypeClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Lists async the Identification Types.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the list of Identification Type.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/identification_types/_identification_types/get/">here</a>.
        /// </remarks>
        public Task<ResourcesList<IdentificationType>> ListAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                "/v1/identification_types",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists the Identification Types.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The list of Identification Type.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/identification_types/_identification_types/get/">here</a>.
        /// </remarks>
        public ResourcesList<IdentificationType> List(
            RequestOptions requestOptions = null)
        {
            return List(
                "/v1/identification_types",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
