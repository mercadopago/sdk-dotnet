namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Refund creation request data.
    /// </summary>
    public class PaymentRefundCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Amount to be refunded.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
