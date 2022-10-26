namespace MercadoPago.Resource.Payment
{
    using System;

    /// <summary>
    /// Payment's fee.
    /// </summary>
    public class PaymentFee
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