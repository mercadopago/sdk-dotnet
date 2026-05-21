namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Request payload for creating a refund on a payment through the MercadoPago Payments API.
    /// Supports both partial refunds (with a specified amount) and total refunds (when amount is <c>null</c>).
    /// Used internally by <see cref="PaymentRefundClient"/>.
    /// </summary>
    public class PaymentRefundCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Amount to be refunded. If <c>null</c>, the full payment amount is refunded.
        /// For partial refunds, specify a value less than or equal to the remaining payment balance.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
