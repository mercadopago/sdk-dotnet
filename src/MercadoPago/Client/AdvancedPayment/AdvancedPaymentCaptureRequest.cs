namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Request payload used to capture a previously authorized advanced payment.
    /// Capturing settles the reserved funds and completes the transaction.
    /// </summary>
    /// <remarks>
    /// This DTO is used internally by <see cref="AdvancedPaymentClient.Capture"/> and
    /// <see cref="AdvancedPaymentClient.CaptureAsync"/> when sending a PUT request to the API.
    /// </remarks>
    public class AdvancedPaymentCaptureRequest
    {
        /// <summary>
        /// Flag indicating the payment should be captured. Always returns <c>true</c>.
        /// </summary>
        public bool Capture => true;
    }
}
