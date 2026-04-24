namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Amount breakdown for a <see cref="PaymentCreateRequest"/>,
    /// specifying the currency and transaction amounts for both the collector (seller)
    /// and the payer (buyer).
    /// </summary>
    public class PaymentAmountsRequest
    {
        /// <summary>
        /// Amount and currency information for the collector (seller) side of the transaction.
        /// </summary>
        /// <seealso cref="PaymentUserAmountsRequest"/>
        public PaymentUserAmountsRequest Collector { get; set; }

        /// <summary>
        /// Amount and currency information for the payer (buyer) side of the transaction.
        /// </summary>
        /// <seealso cref="PaymentUserAmountsRequest"/>
        public PaymentUserAmountsRequest Payer { get; set; }
    }
} 