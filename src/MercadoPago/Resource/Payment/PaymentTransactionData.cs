namespace MercadoPago.Resource.Payment
{
        using System;

    /// <summary>
    /// Payment's transaction data.
    /// </summary>
    public class PaymentTransactionData
    {
        /// <summary>
        /// QR code.
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// QR code image in Base 64.
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// BACEN identifier for Pix.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Bank transfer ID.
        /// </summary>
        public long? BankTransferId { get; set; }

        /// <summary>
        /// Financial institution.
        /// </summary>
        public long? FinancialInstitution { get; set; }

        /// <summary>
        /// URL to access the ticket.
        /// </summary>
        public string TicketUrl { get; set; }

        /// <summary>
        /// Bank info.
        /// </summary>
        public PaymentBankInfo BankInfo { get; set; }

        /// <summary>
        /// First time use.
        /// </summary>
        public bool FirstTimeUse { get; set; }

        /// <summary>
        /// Subscription sequence.
        /// </summary>
        public PaymentSubscriptionSequence SubscriptionSequence { get; set; }

        /// <summary>
        /// Subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Invoice period.
        /// </summary>
        public PaymentInvoicePeriod InvoicePeriod { get; set; }

        /// <summary>
        /// Payment reference.
        /// </summary>
        public PaymentPaymentReference PaymentReference { get; set; }

         /// <summary>
        /// Billing date.
        /// </summary>
        public string BillingDate { get; set; }

    }
}