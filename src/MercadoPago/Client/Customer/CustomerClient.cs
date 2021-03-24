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
    /// Client with methods of Customers APIs.
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
        /// Get async a customer by your ID.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/get/">here</a>.
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
        /// Get a customer by your ID.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/get/">here</a>.
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
        /// Creates a customer as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create the customer.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the created customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers/post/">here</a>.
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
        /// Creates a customer.
        /// </summary>
        /// <param name="request">The data to create the customer.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The created customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers/post/">here</a>.
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
        /// Updates a customer as an asynchronous operation.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="request">The data to update the customer.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the updated customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/put/">here</a>.
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
        /// Updates a customer.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="request">The data to update the customer.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The updated customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference//customers/_customers_id/put/">here</a>.
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
        /// Delete async a customer by your ID.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the deleted customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Delete a customer by your ID.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The deleted customer.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Searches async for customers that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is a page of customers.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_search/get/">here</a>.
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
        /// Searches for customers that match the criteria of <see cref="AdvancedSearchRequest"/>.
        /// </summary>
        /// <param name="request">The search request parameters.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A page of customers.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_search/get/">here</a>.
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
        /// Get async the card of the customer.
        /// </summary>
        /// <param name="id">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
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
        /// Get the card of the customer.
        /// </summary>
        /// <param name="id">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
        /// </remarks>
        public CustomerCard GetCard(
            string id,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return cardClient.Get(id, cardId, requestOptions);
        }

        /// <summary>
        /// Creates a card for customer as an asynchronous operation.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="request">Request to create the card.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the created card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
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
        /// Creates a card for customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">Request to create the card.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The created card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
        /// </remarks>
        public CustomerCard CreateCard(
            string customerId,
            CustomerCardCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return cardClient.Create(customerId, request, requestOptions);
        }

        /// <summary>
        /// Deletes async the card of the customer.
        /// </summary>
        /// <param name="id">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the deleted customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
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
        /// Deletes the card of the customer.
        /// </summary>
        /// <param name="id">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The deleted customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
        /// </remarks>
        public CustomerCard DeleteCard(
            string id,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return cardClient.Delete(id, cardId, requestOptions);
        }

        /// <summary>
        /// List the cards of the customer as an asynchronous operation.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the list of cards.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        public Task<ResourcesList<CustomerCard>> ListCardsAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return cardClient.ListAsync(id, requestOptions, cancellationToken);
        }

        /// <summary>
        /// List the cards of the customer.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The list of cards.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        public ResourcesList<CustomerCard> ListCards(
            string id,
            RequestOptions requestOptions = null)
        {
            return cardClient.List(id, requestOptions);
        }
    }
}
