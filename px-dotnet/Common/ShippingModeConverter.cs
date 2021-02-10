using System;
using System.Text;
using Newtonsoft.Json;

namespace MercadoPago.Common
{
    public class ShippingModeConverter : JsonConverter
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
            return Enum.Parse(typeof(ShipmentMode), SnakeCaseToLowerCase(value), true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ShipmentMode? shipmentMode = (ShipmentMode?)value;
            if (shipmentMode.HasValue)
            {
                writer.WriteValue(PascalCaseToSnakeCase(shipmentMode.ToString()));
            }
        }

        private static string PascalCaseToSnakeCase(string value)
        {
            if (value == null || value.Trim().Length == 0)
            {
                return value;
            }

            value = value.Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(value[0]));
            for (int i = 1; i < value.Length; i++)
            {
                char c = value[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private static string SnakeCaseToLowerCase(string value)
        {
            if (value == null || value.Trim().Length == 0)
            {
                return value;
            }

            StringBuilder sb = new StringBuilder();
            string[] tokens = value.Trim().Split('_');
            for (int i = 0; i < tokens.Length; i++)
            {
                if (!string.IsNullOrEmpty(tokens[i]) && tokens[i].Length > 0)
                {
                    sb.Append(tokens[i]);
                }
            }

            return sb.ToString();
        }
    }
}
