namespace MercadoPago.Serialization
{
    using System.Threading.Tasks;

    /// <summary>
    /// Used to serialize requests and deserialize the responses from MercadoPago's APIs.
    /// The serializer must handle snake case properties and date format must be
    /// <code>yyyy-MM-dd'T'HH:mm:ss.fffK</code>
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserialize the JSON string as a object.
        /// </summary>
        /// <typeparam name="TResponse">The type of response object.</typeparam>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        TResponse DeserializeFromJson<TResponse>(string json) where TResponse : new();

        /// <summary>
        /// Serializes the request as a JSON string.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The serialized request as a JSON string.</returns>
        string SerializeToJson(object request);

        /// <summary>
        /// Serializes the request object as query string parameters.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>
        /// A task whose result is the serialized request as query string parameters.
        /// </returns>
        Task<string> SerializeToQueryStringAsync(object request);
    }
}
