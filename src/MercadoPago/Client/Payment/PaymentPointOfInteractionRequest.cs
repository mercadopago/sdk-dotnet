using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Point of interaction information for a <see cref="PaymentCreateRequest"/>.
    /// Describes the context in which the payment originates, such as a physical POS terminal,
    /// an online checkout, or a subscription-based flow.
    /// </summary>
    public class PaymentPointOfInteractionRequest
    {
        /// <summary>
        /// Identifier of the linked resource or integration (e.g., a subscription or agreement ID).
        /// </summary>
        public string LinkedTo { get; set; }

        /// <summary>
        /// Type of the point of interaction (e.g., "PSP_TRANSFER", "CHECKOUT").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Transaction data associated with this point of interaction, including
        /// subscription sequence, invoice period, and billing details.
        /// </summary>
        /// <seealso cref="PaymentTransactionDataRequest"/>
        public PaymentTransactionDataRequest TransactionData { get; set; }
    }
}
