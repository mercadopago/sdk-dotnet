using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AutoReturnType
    {
        ///<summary>The redirection takes place only for approved payments</summary>
        approved,
        ///<summary>The redirection takes place only for approved payments, forward compatibility only if we change the default behavior</summary>
        all
    }
}
