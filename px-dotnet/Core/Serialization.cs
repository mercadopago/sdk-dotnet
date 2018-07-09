using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MercadoPago
{
    internal static class Serialization
    {
        private static readonly JsonSerializer Serializer =
            new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomSerializationContractResolver(),
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffK"
                    }
                }
            };

        private static readonly JsonSerializer Deserializer =
            new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomDeserializationContractResolver(),
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffK"
                    }
                }
            };

        public static string SerializeValue(object value) =>
            value != null
                ? JToken.FromObject(value, Serializer).ToString()
                : null;

        public static JObject Serialize<T>(this T resource) where T: ResourceBase => 
            JObject.FromObject(resource, Serializer);
        
        public static T Deserialize<T>(this JObject jObject) where T: ResourceBase =>
            jObject.ToObject<T>(Deserializer);

        public static string ToSnakeCase(this string text) => 
            Regex.Replace(text, @"(?<=[a-z0-9])[A-Z\s]", "_$0").ToLower();

        public static JObject GetDiffFromLastChange(JToken jactual, JToken jold)
        {
            // TODO: Please LINQ this.

            var result = new JObject();

            if (((JObject)jactual).Properties().Count() > 0)
            {
                foreach (JProperty x in ((JObject)jactual).Properties())
                {
                    string key = x.Name.ToSnakeCase();

                    if (x.Value.GetType() == typeof(JObject))
                    {
                        if (jold != null)
                        {
                            var new_value = GetDiffFromLastChange(x.Value, ((JObject)jold[x.Name]));
                            if (new_value != null)
                            {
                                if (new_value.Properties().Count() > 0)
                                {
                                    result.Add(key, new_value);
                                }
                            }
                        }
                        else
                        {
                            result.Add(key, x.Value);
                        }
                    }
                    else if (x.Value.GetType() == typeof(JArray))
                    {
                        result.Add(key, x.Value);
                    }
                    else if (x.Value.GetType() == typeof(JValue))
                    {
                        if (jold != null)
                        {
                            if (jold[x.Name] != null)
                            {
                                if ((string)x.Value != (string)jold[x.Name])
                                {
                                    result.Add(key, x.Value);
                                }
                            }
                            else
                            {
                                result.Add(key, x.Value);
                            }
                        }
                        else
                        {
                            result.Add(key, x.Value);
                        }
                    }
                }
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

