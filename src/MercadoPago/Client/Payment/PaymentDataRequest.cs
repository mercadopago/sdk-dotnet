namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment method data within a <see cref="PaymentMethodRequest"/>.
    /// Contains payment rules (discounts, fines, interest) and 3DS authentication information.
    /// </summary>
    public class PaymentDataRequest
    {
        /// <summary>
        /// Payment rules defining discounts, fines, and interest to be applied.
        /// </summary>
        /// <seealso cref="PaymentRulesRequest"/>
        public PaymentRulesRequest Rules { get; set; }

        /// <summary>
        /// 3D Secure authentication data verified by a third party, used for
        /// external authentication flows.
        /// </summary>
        /// <seealso cref="PaymentAuthenticationRequest"/>
        public PaymentAuthenticationRequest authentication { get; set; }
    }
}