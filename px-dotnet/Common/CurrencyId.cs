using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyId
    {
        ARS,
        BRL,
        VEF,
        CLP,
        MXN,
        COP,
        PEN,
        UYU
    }
}
