namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Payment's fee.
    /// </summary>
    public class PaymentFeeRequest
    {

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        public decimal Value { get; set; }
    }
}