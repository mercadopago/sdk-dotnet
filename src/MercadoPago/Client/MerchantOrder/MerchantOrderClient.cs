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
    /// Client with methods of Merchant Order APIs.
    /// </summary>
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
        /// Get async a Merchant Order by your ID.
        /// </summary>
        /// <param name="id">The Merchant Order ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Get a Merchant Order by your ID.
        /// </summary>
        /// <param name="id">The Merchant Order ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a Merchant Order as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create the Merchant Order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a Merchant Order.
        /// </summary>
        /// <param name="request">The data to create the Merchant Order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The created Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Updates a Merchant Order as an asynchronous operation.
        /// </summary>
        /// <param name="id">The ID of the Merchant Order.</param>
        /// <param name="request">The data to update the Merchant Order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the updated Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Updates a Merchant Order.
        /// </summary>
        /// <param name="id">The ID of the Merchant Order.</param>
        /// <param name="request">The data to update the Merchant Order.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>A task whose the result is the updated Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Searches async for Merchant Order that match the criteria of <see cref="SearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is a page of Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Searches for Merchant Order that match the criteria of <see cref="SearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A page of Merchant Order.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
