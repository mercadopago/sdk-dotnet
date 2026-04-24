namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Rules applied to a payment defining early-payment discounts,
    /// late-payment fines, and interest charges. Typically used with
    /// boleto and ticket payment methods. Part of <see cref="PaymentData"/>.
    /// </summary>
    public class PaymentRules
    {

        /// <summary>
        /// List of discount rules applied for early payment.
        /// Each discount specifies a type, value, and expiration date.
        /// </summary>
        /// <seealso cref="PaymentDiscount"/>
        public IList<PaymentDiscount> Discounts { get; set; }

        /// <summary>
        /// Fine (penalty) applied when the payment is made after the due date.
        /// Specifies the fine type and value.
        /// </summary>
        /// <seealso cref="PaymentFee"/>
        public PaymentFee Fine { get; set; }

        /// <summary>
        /// Interest charged on late payments, accumulating after the due date.
        /// Specifies the interest type and value.
        /// </summary>
        /// <seealso cref="PaymentFee"/>
        public PaymentFee Interest { get; set; }
    }
}