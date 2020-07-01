using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethodStatus
    {
        /// <summary> Available for use </summary>
        active,
        /// <summary> Decommissioned, we don't support it anymore </summary>
        deactive,
        /// <summary> Unavailable for use, possible interruption of the service </summary>
        temporally_deactive,
        /// <summary> Unavailable for production use, only available with sandbox credentials</summary>
        testing
    }
}
