namespace MercadoPago.Client.Payment
{
    using MercadoPago.Resource.Payment;

    /// <summary>
    /// Internal request payload used by <see cref="PaymentClient.Cancel"/> and
    /// <see cref="PaymentClient.CancelAsync"/> to cancel a pending payment.
    /// Sets the payment status to <see cref="PaymentStatus.Cancelled"/>.
    /// </summary>
    public class PaymentCancelRequest
    {
        /// <summary>
        /// Payment status value, always set to <see cref="PaymentStatus.Cancelled"/> ("cancelled").
        /// </summary>
        public string Status => PaymentStatus.Cancelled;
    }
}
