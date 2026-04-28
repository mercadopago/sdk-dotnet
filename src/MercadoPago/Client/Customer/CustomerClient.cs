namespace MercadoPago.Client.Customer
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Customer;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Customers API (<c>/v1/customers</c>).
    /// Provides full CRUD operations on customer profiles and convenience methods for managing
    /// the customer's saved cards through an internal <see cref="CustomerCardClient"/> instance.
    /// </summary>
    public class CustomerClient : MercadoPagoClient<Customer>
    {
        private readonly CustomerCardClient cardClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CustomerClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            cardClient = new CustomerCardClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public CustomerClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CustomerClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerClient"/> class.
        /// </summary>
        public CustomerClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a customer by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/get-customer/get/">here</a>.
        /// </remarks>
        public Task<Customer> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{id}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a customer by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/get-customer/get/">here</a>.
        /// </remarks>
        public Customer Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{id}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Creates a new customer profile asynchronously.
        /// </summary>
        /// <param name="request">A <see cref="CustomerRequest"/> with the customer data to create.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/create-customer/post/">here</a>.
        /// </remarks>
        public Task<Customer> CreateAsync(
            CustomerRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                "/v1/customers",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a new customer profile synchronously.
        /// </summary>
        /// <param name="request">A <see cref="CustomerRequest"/> with the customer data to create.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/create-customer/post/">here</a>.
        /// </remarks>
        public Customer Create(
            CustomerRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                "/v1/customers",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Updates an existing customer profile asynchronously.
        /// Only the properties set in <paramref name="request"/> are modified; unset properties remain unchanged.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to update.</param>
        /// <param name="request">A <see cref="CustomerRequest"/> containing the fields to update.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the updated <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/update-customer/put/">here</a>.
        /// </remarks>
        public Task<Customer> UpdateAsync(
            string id,
            CustomerRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{id}",
                HttpMethod.PUT,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Updates an existing customer profile synchronously.
        /// Only the properties set in <paramref name="request"/> are modified; unset properties remain unchanged.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to update.</param>
        /// <param name="request">A <see cref="CustomerRequest"/> containing the fields to update.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The updated <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/update-customer/put">here</a>.
        /// </remarks>
        public Customer Update(
            string id,
            CustomerRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{id}",
                HttpMethod.PUT,
                request,
                requestOptions);
        }

        /// <summary>
        /// Deletes a customer by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the deleted <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<Customer> DeleteAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{id}",
                HttpMethod.DELETE,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a customer by its ID synchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The deleted <see cref="Customer"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Customer Delete(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{id}",
                HttpMethod.DELETE,
                null,
                requestOptions);
        }

        /// <summary>
        /// Searches for customers matching the specified criteria asynchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a paginated list of matching <see cref="Customer"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/search-customer/get/">here</a>.
        /// </remarks>
        public Task<ResultsResourcesPage<Customer>> SearchAsync(
            SearchRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SearchAsync<ResultsResourcesPage<Customer>>(
                "/v1/customers/search",
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Searches for customers matching the specified criteria synchronously.
        /// Supports pagination, sorting, and date-range filtering when an
        /// <see cref="AdvancedSearchRequest"/> is provided.
        /// </summary>
        /// <param name="request">Search parameters including filters, pagination, and optional sorting/date-range criteria.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A paginated list of matching <see cref="Customer"/> resources.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/search-customer/get/">here</a>.
        /// </remarks>
        public ResultsResourcesPage<Customer> Search(
            SearchRequest request,
            RequestOptions requestOptions = null)
        {
            return Search<ResultsResourcesPage<Customer>>(
                "/v1/customers/search",
                request,
                requestOptions);
        }

        /// <summary>
        /// Retrieves a specific saved card for a customer asynchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.GetAsync"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/get-card/get/">here</a>.
        /// </remarks>
        public Task<CustomerCard> GetCardAsync(
            string id,
            string cardId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return cardClient.GetAsync(id, cardId, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific saved card for a customer synchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.Get"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/get-card/get/">here</a>.
        /// </remarks>
        public CustomerCard GetCard(
            string id,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return cardClient.Get(id, cardId, requestOptions);
        }

        /// <summary>
        /// Saves a new card for a customer asynchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.CreateAsync"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to associate the card with.</param>
        /// <param name="request">A <see cref="CustomerCardCreateRequest"/> containing the card token to save.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/save-card/post/">here</a>.
        /// </remarks>
        public Task<CustomerCard> CreateCardAsync(
            string id,
            CustomerCardCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return cardClient.CreateAsync(id, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Saves a new card for a customer synchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.Create"/>.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to associate the card with.</param>
        /// <param name="request">A <see cref="CustomerCardCreateRequest"/> containing the card token to save.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/save-card/post/">here</a>.
        /// </remarks>
        public CustomerCard CreateCard(
            string customerId,
            CustomerCardCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return cardClient.Create(customerId, request, requestOptions);
        }

        /// <summary>
        /// Deletes a saved card from a customer profile asynchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.DeleteAsync"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the deleted <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/delete-card/delete/">here</a>.
        /// </remarks>
        public Task<CustomerCard> DeleteCardAsync(
            string id,
            string cardId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return cardClient.DeleteAsync(id, cardId, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes a saved card from a customer profile synchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.Delete"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The deleted <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/delete-card/delete/">here</a>.
        /// </remarks>
        public CustomerCard DeleteCard(
            string id,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return cardClient.Delete(id, cardId, requestOptions);
        }

        /// <summary>
        /// Lists all saved cards for a customer asynchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.ListAsync"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer whose cards to list.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{CustomerCard}"/> of saved cards.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/get-customer-cards/get/">here</a>.
        /// </remarks>
        public Task<ResourcesList<CustomerCard>> ListCardsAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return cardClient.ListAsync(id, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists all saved cards for a customer synchronously.
        /// This is a convenience wrapper that delegates to <see cref="CustomerCardClient.List"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the customer whose cards to list.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <see cref="ResourcesList{CustomerCard}"/> of saved cards.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/cards/get-customer-cards/get/">here</a>.
        /// </remarks>
        public ResourcesList<CustomerCard> ListCards(
            string id,
            RequestOptions requestOptions = null)
        {
            return cardClient.List(id, requestOptions);
        }
    }
}
