namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Stored Credential class.
    /// </summary>
    public class OrderStoredCredential
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
        /// Store Payment Method.
        /// </summary>
        public bool StorePaymentMethod { get; set; }

        /// <summary>
        /// First Payment.
        /// </summary>
        public bool FirstPayment { get; set; }
    }
}