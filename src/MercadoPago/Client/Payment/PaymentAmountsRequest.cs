namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Amounts request within Payment.
    /// </summary>
    public class PaymentAmountsRequest
    {
        /// <summary>
        /// Collector amounts information.
        /// </summary>
        public PaymentUserAmountsRequest Collector { get; set; }

        /// <summary>
        /// Payer amounts information.
        /// </summary>
        public PaymentUserAmountsRequest Payer { get; set; }
    }
} 