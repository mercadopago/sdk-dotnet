namespace MercadoPago.Client.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client responsible for refunding payment orders via the MercadoPago Orders API.
    /// Supports full-order refunds and partial (per-transaction) refunds through
    /// <c>POST /v1/orders/{id}/refund</c>.
    /// </summary>
    /// <seealso cref="OrderClient"/>
    /// <seealso cref="OrderRefundPaymentRequest"/>
    public class OrderRefundClient : MercadoPagoClient<Order>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefundClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
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
        /// <param name="httpClient">The HTTP client that will be used in HTTP requests.</param>
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
        /// Refunds an order as an asynchronous operation. Pass a <paramref name="request"/>
        /// to perform a partial refund on specific transactions, or omit it for a full refund.
        /// </summary>
        /// <param name="id">The order ID to refund.</param>
        /// <param name="request">Optional refund details specifying transactions and amounts for partial refunds.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose result is the updated order after the refund.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
        /// Refunds an order synchronously. Pass a <paramref name="request"/> to perform a
        /// partial refund on specific transactions, or omit it for a full refund.
        /// </summary>
        /// <param name="id">The order ID to refund.</param>
        /// <param name="request">Optional refund details specifying transactions and amounts for partial refunds.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The updated order after the refund.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
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
