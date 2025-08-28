namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Amounts response from Payment.
    /// </summary>
    public class PaymentAmountsResponse
    {
        /// <summary>
        /// Collector amounts information.
        /// </summary>
        public PaymentCollectorAmountResponse Collector { get; set; }

        /// <summary>
        /// Payer amounts information.
        /// </summary>
        public PaymentPayerAmountResponse Payer { get; set; }
    }
} 