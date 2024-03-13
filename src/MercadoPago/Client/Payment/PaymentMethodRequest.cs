namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment method.
    /// </summary>
    public class PaymentMethodRequest
    {
        /// <summary>
        /// Payment data.
        /// </summary>
        public PaymentDataRequest Data { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }
    }
}