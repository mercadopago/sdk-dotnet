using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PayerType
    {
        ///<summary>Payer is a Customer and belongs to the collector</summary>
        customer,
        ///<summary>The account corresponds to a MercadoPago registered user</summary>
        registered,
        ///<summary>The payer doesn't have an account</summary>
        guest,
        anonymous
    }
}
