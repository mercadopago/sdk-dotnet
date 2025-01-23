namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Stored Credential class.
    /// </summary>       
    public class OrderStoredCredentialRequest
    {
        /// <summary>
        /// Payment Initiator.
        /// </summary>
        public string PaymentInitiator { get; set; }

        /// <summary>
        /// Reason.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Stored Payment Method.
        /// </summary>
        public bool? StoredPaymentMethod { get; set; }

        /// <summary>
        /// First Payment.
        /// </summary>
        public bool FirstPayment { get; set; }
    }

}