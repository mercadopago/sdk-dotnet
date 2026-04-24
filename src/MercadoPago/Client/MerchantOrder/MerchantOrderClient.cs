namespace MercadoPago.Client.MerchantOrder
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.MerchantOrder;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that manages Merchant Order API operations including creation, retrieval,
    /// update, and search.
    /// </summary>
    /// <remarks>
    /// A merchant order groups one or more payments together with shipping information
    /// in marketplace scenarios. It tracks the overall fulfillment status of items
    /// purchased by a buyer, linking payments to shipments.
    /// </remarks>
    public class MerchantOrderClient : MercadoPagoClient<MerchantOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantOrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public MerchantOrderClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantOrderClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public MerchantOrderClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantOrderClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public MerchantOrderClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantOrderClient"/> class.
        /// </summary>
        public MerchantOrderClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a merchant order by its ID as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the merchant order to retrieve.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the merchant order matching the specified ID.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/get/">here</a>.
        /// </remarks>
        public Task<MerchantOrder> GetAsync(
            long id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/merchant_orders/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a merchant order by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the merchant order to retrieve.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The merchant order matching the specified ID.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/get/">here</a>.
        /// </remarks>
        public MerchantOrder Get(
            long id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/merchant_orders/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Creates a merchant order as an asynchronous operation, grouping items,
        /// payments, and shipping details into a single order.
        /// </summary>
        /// <param name="request">The data to create the merchant order, including items, payer, and notification URL.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created merchant order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders/post/">here</a>.
        /// </remarks>
        public Task<MerchantOrder> CreateAsync(
            MerchantOrderCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/merchant_orders",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a merchant order, grouping items, payments, and shipping details
        /// into a single order.
        /// </summary>
        /// <param name="request">The data to create the merchant order, including items, payer, and notification URL.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The newly created merchant order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders/post/">here</a>.
        /// </remarks>
        public MerchantOrder Create(
            MerchantOrderCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                "/merchant_orders",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Updates an existing merchant order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The unique identifier of the merchant order to update.</param>
        /// <param name="request">The fields to update on the merchant order. Only provided fields are modified.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated merchant order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/put/">here</a>.
        /// </remarks>
        public Task<MerchantOrder> UpdateAsync(
            long id,
            MerchantOrderUpdateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/merchant_orders/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Updates an existing merchant order.
        /// </summary>
        /// <param name="id">The unique identifier of the merchant order to update.</param>
        /// <param name="request">The fields to update on the merchant order. Only provided fields are modified.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>The updated merchant order.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_id/put/">here</a>.
        /// </remarks>
        public MerchantOrder Update(
            long id,
            MerchantOrderUpdateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/merchant_orders/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Searches for merchant orders matching the specified criteria as an asynchronous operation.
        /// </summary>
        /// <param name="request">The search parameters including filters, sorting, and pagination.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of merchant orders matching the search criteria.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_search/get/">here</a>.
        /// </remarks>
        public Task<ElementsResourcesPage<MerchantOrder>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ElementsResourcesPage<MerchantOrder>>(
                "/merchant_orders/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for merchant orders matching the specified criteria.
        /// </summary>
        /// <param name="request">The search parameters including filters, sorting, and pagination.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> for custom request configuration such as access tokens or custom headers.</param>
        /// <returns>A paginated list of merchant orders matching the search criteria.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/_merchant_orders_search/get/">here</a>.
        /// </remarks>
        public ElementsResourcesPage<MerchantOrder> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ElementsResourcesPage<MerchantOrder>>(
                "/merchant_orders/search",
                request,
                requestOptions);
        }
    }
}
