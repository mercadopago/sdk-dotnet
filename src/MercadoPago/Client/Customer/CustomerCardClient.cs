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
    /// Client for the MercadoPago Customer Cards API (<c>/v1/customers/{customer_id}/cards</c>).
    /// Manages saved payment cards associated with a customer, supporting CRUD operations
    /// and listing. Typically accessed indirectly through <see cref="CustomerClient"/>
    /// convenience methods (e.g., <see cref="CustomerClient.CreateCardAsync"/>).
    /// </summary>
    public class CustomerCardClient : MercadoPagoClient<CustomerCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCardClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CustomerCardClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCardClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public CustomerCardClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCardClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public CustomerCardClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCardClient"/> class.
        /// </summary>
        public CustomerCardClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Retrieves a specific saved card for a customer asynchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
        /// </remarks>
        public Task<CustomerCard> GetAsync(
            string customerId,
            string cardId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{customerId}/cards/{cardId}",
                HttpMethod.GET,
                requestOptions,
                null,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific saved card for a customer synchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to retrieve.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
        /// </remarks>
        public CustomerCard Get(
            string customerId,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{customerId}/cards/{cardId}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Saves a new card for a customer asynchronously by associating a card token with the customer profile.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to associate the card with.</param>
        /// <param name="request">A <see cref="CustomerCardCreateRequest"/> containing the card token to save.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the newly created <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
        /// </remarks>
        public Task<CustomerCard> CreateAsync(
            string customerId,
            CustomerCardCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{customerId}/cards",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Saves a new card for a customer synchronously by associating a card token with the customer profile.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer to associate the card with.</param>
        /// <param name="request">A <see cref="CustomerCardCreateRequest"/> containing the card token to save.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The newly created <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
        /// </remarks>
        public CustomerCard Create(
            string customerId,
            CustomerCardCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{customerId}/cards",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Deletes a saved card from a customer profile asynchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the deleted <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
        /// </remarks>
        public Task<CustomerCard> DeleteAsync(
            string customerId,
            string cardId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/v1/customers/{customerId}/cards/{cardId}",
                HttpMethod.DELETE,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a saved card from a customer profile synchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer who owns the card.</param>
        /// <param name="cardId">The unique identifier of the card to delete.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The deleted <see cref="CustomerCard"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
        /// </remarks>
        public CustomerCard Delete(
            string customerId,
            string cardId,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/v1/customers/{customerId}/cards/{cardId}",
                HttpMethod.DELETE,
                null,
                requestOptions);
        }

        /// <summary>
        /// Lists all saved cards for a customer asynchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer whose cards to list.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is a <see cref="ResourcesList{CustomerCard}"/> of saved cards.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        public Task<ResourcesList<CustomerCard>> ListAsync(
            string customerId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return ListAsync(
                $"/v1/customers/{customerId}/cards",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists all saved cards for a customer synchronously.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer whose cards to list.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>A <see cref="ResourcesList{CustomerCard}"/> of saved cards.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        public ResourcesList<CustomerCard> List(
            string customerId,
            RequestOptions requestOptions = null)
        {
            return List(
                $"/v1/customers/{customerId}/cards",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }
}
