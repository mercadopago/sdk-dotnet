namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment's rules.
    /// </summary>
    public class PaymentRules
    {

        /// <summary>
        /// Discounts.
        /// </summary>
        public IList<PaymentDiscount> Discounts { get; set; }

        /// <summary>
        /// Fine.
        /// </summary>
        public PaymentFee Fine { get; set; }

        /// <summary>
        /// Interest.
        /// </summary>
        public PaymentFee Interest { get; set; }
    }
}