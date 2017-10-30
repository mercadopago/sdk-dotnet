using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RefundUserType
    {
        /// <summary> The collector issued the refund </summary>
        collector,
        /// <summary> The refund was made by an account's operator </summary>
        @operator,
        /// <summary> The refund was made by a MercadoPago administrator </summary>
        admin,
        /// <summary> The refund was made by the MercadoPago's Buyer Protection Program </summary>
        bpp
    }
}
