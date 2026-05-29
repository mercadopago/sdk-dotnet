// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Stored credential information for recurring or merchant-initiated transactions.
    /// Indicates whether a card-on-file is being used and who initiated the payment,
    /// as required by card network regulations.
    /// </summary>
    /// <seealso cref="OrderPaymentRequest"/>
    public class OrderStoredCredentialRequest
    {
        /// <summary>
        /// Who initiated the payment: "cardholder" for customer-initiated or "merchant" for merchant-initiated transactions.
        /// </summary>
        public string PaymentInitiator { get; set; }

        /// <summary>
        /// Reason for storing the credential (e.g., "recurring_payment", "installment").
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Indicates whether to store the payment method for future transactions.
        /// </summary>
        public bool? StorePaymentMethod { get; set; }

        /// <summary>
        /// Indicates whether this is the first payment in a series of recurring charges.
        /// </summary>
        public bool? FirstPayment { get; set; }

        /// <summary>
        /// Reference to the previous transaction in a recurring series. Required from the second
        /// charge onwards to link this payment to the original card-network authorization.
        /// Type: string (transaction ID).
        /// </summary>
        public string PrevTransactionRef { get; set; }
    }

}
