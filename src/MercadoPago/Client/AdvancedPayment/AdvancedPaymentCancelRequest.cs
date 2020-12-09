namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Resource.AdvancedPayment;

    /// <summary>
    /// Request to cancel a pending payment.
    /// </summary>
    public class AdvancedPaymentCancelRequest
    {
        /// <summary>
        /// Status cancelled.
        /// </summary>
        public string Status => AdvancedPaymentStatus.Cancelled;
    }
}
