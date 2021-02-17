using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Common
{
    [JsonConverter(typeof(ShippingModeConverter))]
    public enum ShipmentMode
    {
        /// <summary>Custom shipping</summary>
        Custom,
        /// <summary>MercadoEnvíos</summary>
        Me2, 
        /// <summary>Shipping mode not specified</summary>
        NotSpecified
    }
}
