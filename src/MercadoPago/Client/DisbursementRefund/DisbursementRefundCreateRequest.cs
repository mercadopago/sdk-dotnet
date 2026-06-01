namespace MercadoPago.Client.DisbursementRefund
{
    /// <summary>
    /// Request body for creating a refund on a specific disbursement within an
    /// advanced payment via <see cref="DisbursementRefundClient.CreateAsync"/> /
    /// <see cref="DisbursementRefundClient.Create"/>.
    /// </summary>
    public class DisbursementRefundCreateRequest
    {
        /// <summary>
        /// Amount to refund. When <c>null</c>, the full disbursement amount is refunded.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
