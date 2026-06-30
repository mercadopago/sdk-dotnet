namespace MercadoPago.Serialization
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Default <see cref="ISerializer"/> implementation backed by Newtonsoft.Json, configured for
    /// the MercadoPago API conventions: snake_case property names, ISO 8601 date formatting,
    /// null-value omission, and invariant culture.
    /// </summary>
    /// <remarks>
    /// The serializer settings are immutable after construction. Property names are automatically
    /// converted to <c>snake_case</c> via <see cref="SnakeCaseNamingStrategy"/>, dates use
    /// the <c>yyyy-MM-dd'T'HH:mm:ss.fffK</c> format, and <c>null</c> properties are excluded
    /// from the serialized output. The <see cref="SerializeToQueryStringAsync"/> method flattens
    /// objects into key-value pairs suitable for URL-encoded query strings.
    /// </remarks>
    public class DefaultSerializer : ISerializer
    {
        private const string DATE_FORMAT_STRING = "yyyy-MM-dd'T'HH:mm:ss.fffK";

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSerializer"/> class, creating
        /// the <see cref="JsonSerializerSettings"/> and <see cref="JsonSerializer"/> with
        /// MercadoPago-compatible defaults.
        /// </summary>
        public DefaultSerializer()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
                DateFormatString = DATE_FORMAT_STRING,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                Culture = CultureInfo.InvariantCulture,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            JsonSerializer = JsonSerializer.Create(JsonSerializerSettings);
        }

        /// <summary>
        /// Gets the <see cref="Newtonsoft.Json.JsonSerializerSettings"/> that define snake_case naming,
        /// date formatting, null handling, and other serialization conventions.
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings { get; }

        /// <summary>
        /// Gets the <see cref="Newtonsoft.Json.JsonSerializer"/> instance created from
        /// <see cref="JsonSerializerSettings"/>, used internally for object-to-JToken conversion.
        /// </summary>
        public JsonSerializer JsonSerializer { get; }

        /// <summary>
        /// Deserializes a JSON string into an instance of <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">
        /// The target type to deserialize into. Must have a parameterless constructor.
        /// </typeparam>
        /// <param name="json">The JSON string to deserialize. Must not be <c>null</c>.</param>
        /// <returns>A new instance of <typeparamref name="TResponse"/> populated from the JSON data.</returns>
        public TResponse DeserializeFromJson<TResponse>(string json) where TResponse : new()
        {
            return JsonConvert.DeserializeObject<TResponse>(json, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the specified object into a JSON string using snake_case property names
        /// and the configured date format.
        /// </summary>
        /// <param name="request">The object to serialize. Null properties are omitted from the output.</param>
        /// <returns>A JSON string representation of <paramref name="request"/>.</returns>
        public string SerializeToJson(object request)
        {
            return JsonConvert.SerializeObject(request, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the specified object into a URL-encoded query string by recursively
        /// flattening its properties into key-value pairs using snake_case names.
        /// </summary>
        /// <param name="request">
        /// The object to serialize. If <c>null</c>, an empty string is returned.
        /// </param>
        /// <returns>
        /// A <see cref="Task{String}"/> whose result is the URL-encoded query string
        /// (e.g., <c>external_reference=abc&amp;status=approved</c>).
        /// </returns>
        public Task<string> SerializeToQueryStringAsync(object request)
        {
            IDictionary<string, string> dictionary = ParseToDictionary(request);
            if (dictionary == null)
            {
                return Task.FromResult(string.Empty);
            }

            var urlEncoded = new FormUrlEncodedContent(dictionary);
            return urlEncoded.ReadAsStringAsync();
        }

        private IDictionary<string, string> ParseToDictionary(object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                var jObject = JObject.FromObject(metaToken, JsonSerializer);
                return ParseToDictionary(jObject);
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    IDictionary<string, string> childContent = ParseToDictionary(child);
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                                                 .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            string value = jValue?.Type == JTokenType.Date ?
                jValue?.ToString(DATE_FORMAT_STRING, CultureInfo.InvariantCulture) :
                jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}
