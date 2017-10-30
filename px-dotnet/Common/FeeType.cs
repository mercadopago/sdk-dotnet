using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeeType
    {
        /// <summary> Cost for using MercadoPago </summary>
        mercadopago_fee,
        /// <summary> Discount given by a coupon </summary>
        coupon_fee,
        /// <summary> Cost of financing </summary>
        financing_fee,
        /// <summary> Shipping cost </summary>
        shipping_fee,
        /// <summary> Marketplace comision for the service </summary>
        application_fee,
        /// <summary> Discount given by the seller through cost absorption </summary>
        discount_fee
    }
}
