namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment rules within <see cref="PaymentDataRequest"/> that define financial conditions
    /// such as early payment discounts, late payment fines, and interest charges.
    /// </summary>
    public class PaymentRulesRequest
    {

        /// <summary>
        /// List of discount rules for early payment, each with a type, value, and expiration date.
        /// </summary>
        /// <seealso cref="PaymentDiscountRequest"/>
        public IList<PaymentDiscountRequest> Discounts { get; set; }

        /// <summary>
        /// Fine or penalty applied for late payment.
        /// </summary>
        /// <seealso cref="PaymentFeeRequest"/>
        public PaymentFeeRequest Fine { get; set; }

        /// <summary>
        /// Interest charges applied for delayed payment.
        /// </summary>
        /// <seealso cref="PaymentFeeRequest"/>
        public PaymentFeeRequest Interest { get; set; }
    }
}