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
    /// The default serializer used.
    /// Uses the <c>Newtonsoft.JSON</c> library.
    /// </summary>
    public class DefaultSerializer : ISerializer
    {
        private const string DATE_FORMAT_STRING = "yyyy-MM-dd'T'HH:mm:ss.fffK";

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSerializer"/> class.
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
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                Culture = CultureInfo.InvariantCulture,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            JsonSerializer = JsonSerializer.Create(JsonSerializerSettings);
        }

        /// <summary>
        /// <see cref="JsonSerializerSettings"/> used to serialize and deserialize.
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings { get; }

        /// <summary>
        /// <see cref="JsonSerializer"/> user by the serializer.
        /// </summary>
        public JsonSerializer JsonSerializer { get; }

        /// <summary>
        /// Deserialize the JSON string as a object.
        /// </summary>
        /// <typeparam name="TResponse">The type of response object.</typeparam>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public TResponse DeserializeFromJson<TResponse>(string json) where TResponse : new()
        {
            return JsonConvert.DeserializeObject<TResponse>(json, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the request object as a JSON string.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The serialized request as a JSON string.</returns>
        public string SerializeToJson(object request)
        {
            return JsonConvert.SerializeObject(request, JsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the request object as query string parameters.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>
        /// A task whose result is the serialized request as query string parameters.
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
