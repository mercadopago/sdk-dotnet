namespace MercadoPago.Client.Payment
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Payment's discount.
    /// </summary>
    public class PaymentDiscountRequest
    {

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Limit date.
        /// </summary>
        [JsonConverter(typeof(DateWithoutHourConverter))]
        public DateTime LimitDate { get; set; }
    }
}