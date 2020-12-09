namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Refund creation request data.
    /// </summary>
    public class AdvancedPaymentRefundCreateRequest
    {
        /// <summary>
        /// Amount to be refunded.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
