using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityCodeMode
    {
        /// <summary> The security code should be given to process the payment </summary>
        mandatory,
        /// <summary> A payment could be issued without the security code </summary>
        optional
    }
}
