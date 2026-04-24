// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents credential-on-file information for an <see cref="OrderPayment"/>, used in
    /// merchant-initiated transactions and recurring payment scenarios as required by card network rules.
    /// </summary>
    public class OrderStoredCredential
    {
        /// <summary>
        /// Entity that initiated this payment. Possible values: "cardholder" (customer-initiated) or "merchant" (merchant-initiated).
        /// </summary>
        public string PaymentInitiator { get; set; }

        /// <summary>
        /// Reason for using stored credentials (e.g., "recurring", "installment", "unscheduled").
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Indicates whether the payer's payment method should be stored for future transactions.
        /// </summary>
        public bool? StorePaymentMethod { get; set; }

        /// <summary>
        /// Indicates whether this is the first payment in a series using these stored credentials.
        /// </summary>
        public bool? FirstPayment { get; set; }
    }
}
