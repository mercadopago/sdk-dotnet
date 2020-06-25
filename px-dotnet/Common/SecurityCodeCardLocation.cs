using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityCodeCardLocation
    {
        /// <summary> The security code is located in the back of the card </summary>
        back,
        /// <summary> The security code is located in the front of the card </summary>
        front
    }
}
