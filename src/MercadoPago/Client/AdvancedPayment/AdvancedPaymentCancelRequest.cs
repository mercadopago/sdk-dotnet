namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Resource.AdvancedPayment;

    /// <summary>
    /// Request payload used to cancel a pending advanced payment by setting its status to cancelled.
    /// Only advanced payments in a pending state can be cancelled.
    /// </summary>
    /// <remarks>
    /// This DTO is used internally by <see cref="AdvancedPaymentClient.Cancel"/> and
    /// <see cref="AdvancedPaymentClient.CancelAsync"/> when sending a PUT request to the API.
    /// </remarks>
    public class AdvancedPaymentCancelRequest
    {
        /// <summary>
        /// Payment status value, always set to <see cref="AdvancedPaymentStatus.Cancelled"/>.
        /// </summary>
        public string Status => AdvancedPaymentStatus.Cancelled;
    }
}
