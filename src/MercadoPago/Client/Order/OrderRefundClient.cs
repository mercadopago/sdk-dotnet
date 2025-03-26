namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that use the Order APIs.
    /// </summary>
    public class OrderRefundClient : MercadoPagoClient<Order>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderRefundClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public OrderRefundClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefundClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public OrderRefundClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefundClient"/> class.
        /// </summary>
        public OrderRefundClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Process a order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order refund partial.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/create/post/">here</a>.
        /// </remarks>
        public Task<Order> RefundAsync(
            string id,
            OrderRefundPaymentRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/v1/orders/{id}/refund", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Process a order.
        /// </summary>
        /// <param name="id">The order id.</param>
        /// <param name="request">The order refund partial.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The created order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com.br/developers/en/reference/order/online-payments/create/post">here</a>.
        /// </remarks>
        public Order Refund(
            string id,
            OrderRefundPaymentRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Send($"/v1/orders/{id}/refund", HttpMethod.POST, request, requestOptions);
        }

    }
}
