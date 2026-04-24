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
    /// Client for the MercadoPago Identification Types API (<c>/v1/identification_types</c>).
    /// Returns the list of accepted government-issued document types (e.g., CPF, CNPJ, DNI)
    /// for the country associated with the current access token. The results are used to
    /// populate the <see cref="Common.IdentificationRequest.Type"/> field in payment and customer requests.
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
        /// Lists all available identification types asynchronously for the country
        /// associated with the current access token.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{IdentificationType}"/> of accepted document types.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
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
        /// Lists all available identification types synchronously for the country
        /// associated with the current access token.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <see cref="ResourcesList{IdentificationType}"/> of accepted document types.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
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
