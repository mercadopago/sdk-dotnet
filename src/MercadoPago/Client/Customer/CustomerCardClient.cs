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
    /// Client with methods of Customer Cards APIs.
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
        /// Get async the card of the customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
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
        /// Get the card of the customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// Creates a card for customer as an asynchronous operation.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
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
        /// Deletes async the card of the customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
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
        /// Deletes the card of the customer.
        /// </summary>
        /// <param name="customerId">The customer ID.</param>
        /// <param name="cardId">The card ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The deleted customer card.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// List the cards of the customer as an asynchronous operation.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task whose the result is the list of cards.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
        /// List the cards of the customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/></param>
        /// <returns>The list of cards.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
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
