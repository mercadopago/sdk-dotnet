namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Internal request payload used by <see cref="PaymentClient.Capture"/> and
    /// <see cref="PaymentClient.CaptureAsync"/> to capture a previously authorized payment.
    /// Supports capturing for the full amount or a partial amount.
    /// </summary>
    public class PaymentCaptureRequest
    {
        /// <summary>
        /// Capture flag, always <c>true</c>. Signals the API to transition the payment
        /// from "authorized" to "approved" status.
        /// </summary>
        public bool Capture => true;

        /// <summary>
        /// Amount to capture. If <c>null</c>, the full authorized amount is captured.
        /// Set a value less than the original authorization for partial capture.
        /// </summary>
        public decimal? TransactionAmount { get; set; }
    }
}
