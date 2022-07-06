namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Point of interaction.
    /// </summary>
    public class PaymentPointOfInteraction
    {
        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sub type.
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Linked To
        /// </summary>
        public string LinkedTo { get; set; }

        /// <summary>
        /// Application data.
        /// </summary>
        public PaymentApplicationData ApplicationData { get; set; }

        /// <summary>
        /// Transaction data.
        /// </summary>
        public PaymentTransactionData TransactionData { get; set; }
    }
}
