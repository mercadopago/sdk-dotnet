using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethodDeferredCapture
    {
        /// <summary> This payment method supports authorization and capture operations </summary>
        supported,
        /// <summary> Deferred capture is not available for this payment method </summary>
        unsupported,
        /// <summary> Cash payment methods don't allow deferred capture </summary>
        does_not_apply
    }
}
