namespace MercadoPago.Resource.Payment
{
    using System;

    /// <summary>
    /// Represents a fee configuration (fine or interest) applied to a payment
    /// as part of the <see cref="PaymentRules"/>.
    /// </summary>
    public class PaymentFee
    {

        /// <summary>
        /// Type of fee. Indicates the calculation method
        /// (e.g., fixed amount or percentage).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Fee value. The interpretation depends on the <see cref="Type"/>
        /// (e.g., a percentage value or a fixed currency amount).
        /// </summary>
        public decimal Value { get; set; }

    }
}