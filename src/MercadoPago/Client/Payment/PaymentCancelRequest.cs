namespace MercadoPago.Client.Payment
{
    using MercadoPago.Resource.Payment;

    /// <summary>
    /// Request to cancel a pending payment.
    /// </summary>
    public class PaymentCancelRequest
    {
        /// <summary>
        /// Status cancelled.
        /// </summary>
        public string Status => PaymentStatus.Cancelled;
    }
}
