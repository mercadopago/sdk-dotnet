using System;
using System.Collections.Generic;
using System.Reflection;
using MercadoPago.Insight.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MercadoPago.Insight.Converters
{
    public class TrafficLightResponseConverter : JsonConverter
    {
        private readonly IDictionary<String, String> _propertyMappings = new Dictionary<String, String>
        {
            { "send_insight_data", "send-data" },
            { "send_ttl", "ttl" },
            { "endpoint_whitelist", "endpoint-whitelist" },
            { "base64_encode_data", "base64-encode-data" },
        };

        public override Boolean CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Boolean CanConvert(Type objectType)
        {
            return objectType == typeof(TrafficLightResponse);
        }

        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            Object instance = Activator.CreateInstance(objectType);
            PropertyInfo[] props = objectType.GetProperties();

            JObject jObject = JObject.Load(reader);
            foreach (JProperty jProperty in jObject.Properties())
            {
                String propertyName;
                if (!_propertyMappings.TryGetValue(jProperty.Name, out propertyName))
                {
                    propertyName = jProperty.Name;   
                }

                PropertyInfo prop = null;
                for (int i = 0; i < props.Length; i++)
                {
                    prop = props[i];
                    if (prop != null)
                    {
                        Object[] attributes = prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                        if (prop.CanWrite && attributes != null && attributes.Length > 0 
                                && ((JsonPropertyAttribute)attributes[0]).PropertyName == propertyName)
                        {
                            prop.SetValue(instance, jProperty.Value.ToObject(prop.PropertyType, serializer), null);
                        }
                    }
                }
            }

            return instance;
        }
    }
}