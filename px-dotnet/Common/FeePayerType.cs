using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeePayerType
    {
        /// <summary> The seller absorbs the cost </summary>
        collector,
        /// <summary> The buyer absorbs the cost </summary>
        payer
    }
}
