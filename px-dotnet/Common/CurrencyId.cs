using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyId
    {
        /// <summary> Argentine peso </summary>
        ARS,
        /// <summary> Brazilian real </summary>
        BRL,
        /// <summary> Venezuelan strong bolivar </summary>
        VEF,
        /// <summary> Chilean peso </summary>
        CLP,
        /// <summary> Mexican peso </summary>
        MXN,
        /// <summary> Colombian peso </summary>
        COP,
        /// <summary> Peruvian sol </summary>
        PEN,
        /// <summary> Uruguayan peso </summary>
        UYU
    }
}
