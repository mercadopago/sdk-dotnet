namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Fee or penalty applied to a payment within <see cref="PaymentRulesRequest"/>.
    /// Used to represent fines for late payment or interest charges.
    /// </summary>
    public class PaymentFeeRequest
    {

        /// <summary>
        /// Fee type (e.g., "fixed", "percentage").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Fee value, either a fixed amount or percentage depending on <see cref="Type"/>.
        /// </summary>
        public decimal Value { get; set; }
    }
}