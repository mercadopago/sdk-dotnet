namespace MercadoPago.Client.PaymentMethod
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.PaymentMethod;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client with methods of Payment Method APIs.
    /// </summary>
    public class PaymentMethodClient : MercadoPagoClient<PaymentMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentMethodClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PaymentMethodClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PaymentMethodClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodClient"/> class.
        /// </summary>
        public PaymentMethodClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Lists async the Payment Methods.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the list of Payment Method.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payment_methods/_payment_methods/get/">here</a>.
        /// </remarks>
        public Task<ResourcesList<PaymentMethod>> ListAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                "/v1/payment_methods",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists the Payment Methods.
        /// </summary>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The list of Payment Method.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payment_methods/_payment_methods/get/">here</a>.
        /// </remarks>
        public ResourcesList<PaymentMethod> List(
            RequestOptions requestOptions = null)
        {
            return List(
                "/v1/payment_methods",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
