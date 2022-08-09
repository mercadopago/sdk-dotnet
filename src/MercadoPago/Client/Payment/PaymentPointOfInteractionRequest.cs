using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Point of Interaction information.
    /// </summary>
    public class PaymentPointOfInteractionRequest
    {
        /// <summary>
        /// Linked To.
        /// </summary>
        public string LinkedTo { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Transaction data.
        /// </summary>
        public PaymentTransactionDataRequest TransactionData { get; set; }
    }
}
