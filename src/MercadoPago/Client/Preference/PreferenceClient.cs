namespace MercadoPago.Client.Preference
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource.Preference;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client that use the Preferences APIs.
    /// </summary>
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
        /// Get async a preference by your ID.
        /// </summary>
        /// <param name="id">The preference id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/_checkout_preferences_id/get/">here</a>.
        /// </remarks>
        public Task<Preference> GetAsync(
            string id,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync($"/checkout/preferences/{id}", HttpMethod.GET, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Get async a preference by your ID.
        /// </summary>
        /// <param name="id">The preference id.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>A task whose the result is the preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/_checkout_preferences_id/get/">here</a>.
        /// </remarks>
        public Preference Get(
            string id,
            RequestOptions requestOptions = null)
        {
            return Send($"/checkout/preferences/{id}", HttpMethod.GET, null, requestOptions);
        }

        /// <summary>
        /// Creates a preference as an asynchronous operation.
        /// </summary>
        /// <param name="request">The data to create a preference.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the created preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/post/">here</a>.
        /// </remarks>
        public Task<Preference> CreateAsync(
            PreferenceRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync("/checkout/preferences", HttpMethod.POST, request, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a preference.
        /// </summary>
        /// <param name="request">The data to create a preference.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The created preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/post/">here</a>.
        /// </remarks>
        public Preference Create(
            PreferenceRequest request,
            RequestOptions requestOptions = null)
        {
            return Send("/checkout/preferences", HttpMethod.POST, request, requestOptions);
        }

        /// <summary>
        /// Updates a preference as an asynchronous operation.
        /// Just send in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The preference ID.</param>
        /// <param name="request">The data to update a preference.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task whose the result is the updated preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/put/">here</a>.
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
        /// Updates a preference.
        /// Just send in <paramref name="request"/> the properties you want to update.
        /// </summary>
        /// <param name="id">The preference ID.</param>
        /// <param name="request">The data to update a preference.</param>
        /// <param name="requestOptions"><see cref="RequestOptions"/>.</param>
        /// <returns>The updated preference.</returns>
        /// <exception cref="MercadoPagoException">If a unexpected exception occurs.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns a error.</exception>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/put/">here</a>.
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
