namespace MercadoPago.Client.Preference
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Preference;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that manages the full lifecycle of Checkout Pro preferences, including
    /// creation, retrieval, and updates. Use this client to configure the payment experience
    /// for buyers via the MercadoPago Checkout Preferences API.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    /// <seealso cref="MercadoPago.Resource.Preference.Preference"/>
    public class PreferenceClient : MercadoPagoClient<Preference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreferenceClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreferenceClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferenceClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PreferenceClient(IHttpClient httpClient)
            : base(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferenceClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PreferenceClient(ISerializer serializer)
            : base(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreferenceClient"/> class.
        /// </summary>
        public PreferenceClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Retrieves a checkout preference by its ID as an asynchronous operation.
        /// </summary>
        /// <param name="id">The preference ID returned when the preference was created.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        /// <returns>A task whose result is the <see cref="Preference"/> with the current preference data.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/get-preference/get">here</a>.
        /// </remarks>
        public Task<Preference> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/checkout/preferences/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Retrieves a checkout preference by its ID.
        /// </summary>
        /// <param name="id">The preference ID returned when the preference was created.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <returns>The <see cref="Preference"/> with the current preference data.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/get-preference/get">here</a>.
        /// </remarks>
        public Preference Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/checkout/preferences/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Creates a new Checkout Pro preference as an asynchronous operation.
        /// </summary>
        /// <param name="request">The <see cref="PreferenceRequest"/> with items, payer data, and checkout configuration.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        /// <returns>A task whose result is the created <see cref="Preference"/> including its generated ID and init point URL.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/create-preference/post/">here</a>.
        /// </remarks>
        public Task<Preference> CreateAsync(
            PreferenceRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/checkout/preferences", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a new Checkout Pro preference.
        /// </summary>
        /// <param name="request">The <see cref="PreferenceRequest"/> with items, payer data, and checkout configuration.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <returns>The created <see cref="Preference"/> including its generated ID and init point URL.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/create-preference/post/">here</a>.
        /// </remarks>
        public Preference Create(
            PreferenceRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/checkout/preferences", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Updates an existing checkout preference as an asynchronous operation.
        /// Only include in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The preference ID to update.</param>
        /// <param name="request">The <see cref="PreferenceRequest"/> containing only the fields to modify.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
        /// <returns>A task whose result is the updated <see cref="Preference"/>.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/update-preference/put">here</a>.
        /// </remarks>
        public Task<Preference> UpdateAsync(
            string id,
            PreferenceRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/checkout/preferences/{id}", HttpMethod.PUT, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Updates an existing checkout preference.
        /// Only include in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The preference ID to update.</param>
        /// <param name="request">The <see cref="PreferenceRequest"/> containing only the fields to modify.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/> with custom headers or access token.</param>
        /// <returns>The updated <see cref="Preference"/>.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-pro/preferences/update-preference/put">here</a>.
        /// </remarks>
        public Preference Update(
            string id,
            PreferenceRequest request,
            RequestOptions requestOptions = null)
        {
            return Send($"/checkout/preferences/{id}", HttpMethod.PUT, request, requestOptions);
        }
    }
}
