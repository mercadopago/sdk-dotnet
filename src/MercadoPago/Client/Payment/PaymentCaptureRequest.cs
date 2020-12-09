namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Request to capture a payment.
    /// </summary>
    public class PaymentCaptureRequest
    {
        /// <summary>
        /// Capture (<c>true</c>).
        /// </summary>
        public bool Capture => true;

        /// <summary>
        /// The amount to capture.
        /// </summary>
        public decimal? TransactionAmount { get; set; }
    }
}
