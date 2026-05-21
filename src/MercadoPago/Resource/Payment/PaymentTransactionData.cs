namespace MercadoPago.Resource.Payment
{
    using System;

    /// <summary>
    /// Transaction-specific data generated at the <see cref="PaymentPointOfInteraction"/>,
    /// including QR codes for Pix payments, ticket URLs for boleto payments,
    /// bank information, and subscription details.
    /// </summary>
    public class PaymentTransactionData
    {
        /// <summary>
        /// QR code string content for Pix payments. Can be used to generate
        /// a QR code image on the client side.
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// Base64-encoded QR code image for Pix payments. Ready to be displayed
        /// directly in an HTML <c>&lt;img&gt;</c> tag.
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// BACEN (Central Bank of Brazil) transaction identifier for Pix payments.
        /// Used for traceability and reconciliation within the Pix network.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Unique identifier of the bank transfer used to process this payment.
        /// </summary>
        public long? BankTransferId { get; set; }

        /// <summary>
        /// Identifier of the financial institution that processed this transaction.
        /// </summary>
        public long? FinancialInstitution { get; set; }

        /// <summary>
        /// URL where the payer can view or download the payment ticket
        /// (e.g., a boleto PDF or a cash payment voucher).
        /// </summary>
        public string TicketUrl { get; set; }

        /// <summary>
        /// Bank account information for both the payer and collector
        /// involved in this transaction. Used for bank transfers and Pix.
        /// </summary>
        /// <seealso cref="PaymentBankInfo"/>
        public PaymentBankInfo BankInfo { get; set; }

        /// <summary>
        /// Indicates whether this is the first payment in a subscription
        /// series (<c>true</c>) or a subsequent recurring charge (<c>false</c>).
        /// </summary>
        public bool FirstTimeUse { get; set; }

        /// <summary>
        /// Sequence information for subscription-based payments, indicating
        /// the current position within the subscription cycle.
        /// </summary>
        /// <seealso cref="PaymentSubscriptionSequence"/>
        public PaymentSubscriptionSequence SubscriptionSequence { get; set; }

        /// <summary>
        /// Unique identifier of the subscription plan associated with this
        /// recurring payment.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Billing period information for subscription payments, defining
        /// the cycle length and type (e.g., monthly, yearly).
        /// </summary>
        /// <seealso cref="PaymentInvoicePeriod"/>
        public PaymentInvoicePeriod InvoicePeriod { get; set; }

        /// <summary>
        /// Reference to the original or related payment in a subscription
        /// or recurring payment series.
        /// </summary>
        /// <seealso cref="PaymentPaymentReference"/>
        public PaymentPaymentReference PaymentReference { get; set; }

        /// <summary>
        /// Billing date for subscription payments, indicating when this
        /// particular charge was or will be billed.
        /// </summary>
        public string BillingDate { get; set; }

        /// <summary>
        /// Indicates whether the payer was physically present during the
        /// transaction. Relevant for POS and in-person payment scenarios.
        /// </summary>
        public bool? UserPresent { get; set; }

    }
}