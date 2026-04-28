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
    /// Client for the MercadoPago Payment Methods API (<c>/v1/payment_methods</c>).
    /// Returns the list of payment methods available for the country associated with
    /// the current access token (e.g., credit cards, debit cards, bank transfers, cash).
    /// Useful for building payment forms that display only relevant options to the buyer.
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
        /// Lists all available payment methods asynchronously for the country
        /// associated with the current access token.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{PaymentMethod}"/> of available payment methods.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/payment-methods/get/">here</a>.
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
        /// Lists all available payment methods synchronously for the country
        /// associated with the current access token.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <see cref="ResourcesList{PaymentMethod}"/> of available payment methods.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/payment-methods/get/">here</a>.
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
