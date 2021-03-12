using System;
using System.Globalization;
using Newtonsoft.Json;

namespace MercadoPago.Common
{
    public class StringDecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Convert.ToDecimal(float.Parse(value, CultureInfo.InvariantCulture));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            decimal? decimalValue = (decimal?)value;
            if (decimalValue.HasValue)
            {
                writer.WriteValue(decimalValue.Value.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
