namespace MercadoPago.Resource.Payment
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Discount rule applied to a payment, defining the type of discount,
    /// its value, and the deadline for the discount to be valid.
    /// Part of the <see cref="PaymentRules"/> configuration.
    /// </summary>
    public class PaymentDiscount
    {

        /// <summary>
        /// Type of discount applied. Indicates the discount calculation method
        /// (e.g., fixed amount or percentage).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Discount value. The interpretation depends on the <see cref="Type"/>
        /// (e.g., a percentage value or a fixed currency amount).
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Deadline date (without time) until which the discount is valid.
        /// Payments made after this date will not receive this discount.
        /// </summary>
        [JsonConverter(typeof(DateWithoutHourConverter))]
        public DateTime LimitDate { get; set; }
    }
}