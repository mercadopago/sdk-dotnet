namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment's data.
    /// </summary>
    public class PaymentDataRequest
    {
        /// <summary>
        /// Payment rules.
        /// </summary>
        public PaymentRulesRequest Rules { get; set; }

        /// <summary>
        /// Authentication.
        /// </summary>
        public PaymentAuthenticationRequest authentication { get; set; }
    }
}