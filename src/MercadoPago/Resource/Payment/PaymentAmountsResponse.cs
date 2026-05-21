namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Breakdown of payment amounts for both the collector (seller) and
    /// the payer (buyer), including currency and net values.
    /// </summary>
    public class PaymentAmountsResponse
    {
        /// <summary>
        /// Amount information from the collector's (seller's) perspective,
        /// including the currency, transaction amount, and net received amount.
        /// </summary>
        /// <seealso cref="PaymentCollectorAmountResponse"/>
        public PaymentCollectorAmountResponse Collector { get; set; }

        /// <summary>
        /// Amount information from the payer's (buyer's) perspective,
        /// including the currency, transaction amount, and total paid.
        /// </summary>
        /// <seealso cref="PaymentPayerAmountResponse"/>
        public PaymentPayerAmountResponse Payer { get; set; }
    }
} 