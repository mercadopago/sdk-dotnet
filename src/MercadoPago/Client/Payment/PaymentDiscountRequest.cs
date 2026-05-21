namespace MercadoPago.Client.Payment
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Discount rule applied to a payment within <see cref="PaymentRulesRequest"/>.
    /// Defines the type, value, and expiration date for an early payment discount.
    /// </summary>
    public class PaymentDiscountRequest
    {

        /// <summary>
        /// Discount type (e.g., "fixed", "percentage").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Discount value, either a fixed amount or percentage depending on <see cref="Type"/>.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Deadline date for applying this discount. Payments made after this date
        /// will not receive the discount. Serialized as a date without time component.
        /// </summary>
        [JsonConverter(typeof(DateWithoutHourConverter))]
        public DateTime LimitDate { get; set; }
    }
}