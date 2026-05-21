namespace MercadoPago.Serialization
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the contract for serializing SDK request objects to JSON (or query strings) and
    /// deserializing API response bodies back into typed objects.
    /// </summary>
    /// <remarks>
    /// Implementations must apply snake_case property naming and use the date format
    /// <c>yyyy-MM-dd'T'HH:mm:ss.fffK</c> to match MercadoPago API conventions.
    /// The default implementation is <see cref="DefaultSerializer"/>. Assign a custom
    /// implementation to <see cref="Config.MercadoPagoConfig.Serializer"/> before making API calls.
    /// </remarks>
    public interface ISerializer
    {
        /// <summary>
        /// Deserializes a JSON string into an instance of <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">
        /// The target type to deserialize into. Must have a parameterless constructor.
        /// </typeparam>
        /// <param name="json">The JSON string received from the API response body.</param>
        /// <returns>A new instance of <typeparamref name="TResponse"/> populated from the JSON data.</returns>
        TResponse DeserializeFromJson<TResponse>(string json) where TResponse : new();

        /// <summary>
        /// Serializes the specified request object into a JSON string suitable for an API request body.
        /// </summary>
        /// <param name="request">The request object to serialize.</param>
        /// <returns>A JSON string representation of <paramref name="request"/>.</returns>
        string SerializeToJson(object request);

        /// <summary>
        /// Serializes the specified request object into a URL-encoded query string for use in GET requests.
        /// </summary>
        /// <param name="request">The request object whose properties become query string parameters.</param>
        /// <returns>
        /// A <see cref="Task{String}"/> whose result is the URL-encoded query string.
        /// </returns>
        Task<string> SerializeToQueryStringAsync(object request);
    }
}
