namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Point of interaction
    /// </summary>
    public class PointOfInteraction
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sub Type
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Linked To
        /// </summary>
        public string linkedTo { get; set; }

        /// <summary>
        /// Appication Data
        /// </summary>
        public ApplicationData ApplicationData { get; set; }

        /// <summary>
        /// Transaction data
        /// </summary>
        public TransactionData TransactionData { get; set; }
    }
}
