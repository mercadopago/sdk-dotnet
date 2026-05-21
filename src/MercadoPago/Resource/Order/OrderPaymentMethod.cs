// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the payment method used in an <see cref="OrderPayment"/>, including card details,
    /// offline payment data (tickets, barcodes), PIX transfer fields, and 3-D Secure configuration.
    /// </summary>
    public class OrderPaymentMethod
    {
        /// <summary>
        /// Payment method identifier (e.g., "visa", "master", "pix", "bolbradesco", "account_money").
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the saved card on file, used for returning customers with tokenized cards.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Payment method type category (e.g., "credit_card", "debit_card", "bank_transfer", "ticket").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of installments selected by the payer for this payment.
        /// </summary>
        public int Installments { get; set; }

        /// <summary>
        /// Secure, single-use token representing the payer's card data, generated client-side by the MercadoPago SDK.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Text that appears on the payer's card statement to identify the charge (e.g., "MERCADOPAGO").
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// URL where the payer can view or download the offline payment ticket (e.g., boleto, OXXO voucher).
        /// </summary>
        public string TicketUrl { get; set; }

        /// <summary>
        /// Barcode content string for offline payment methods, used to generate scannable barcodes.
        /// </summary>
        public string BarcodeContent { get; set; }

        /// <summary>
        /// Payment reference code provided by the payment provider, used by the payer to complete offline payments.
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Unique reference identifier assigned by the payment provider for tracking and reconciliation.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Verification code associated with the payment, used for validation or confirmation purposes.
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Financial institution identifier for bank transfer payment methods (e.g., bank code or name).
        /// </summary>
        public string FinancialInstitution { get; set; }

        /// <summary>
        /// QR code content string for PIX or QR-based payment methods, used to generate the QR image.
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// Base64-encoded image of the QR code, ready to be rendered directly in the checkout interface.
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// Digitable line (linha digitavel) for Brazilian boleto payments, allowing manual entry by the payer.
        /// </summary>
        public string DigitableLine { get; set; }

        /// <summary>
        /// 3-D Secure transaction security data used for card authentication and fraud prevention.
        /// See <see cref="OrderTransactionSecurity"/> for challenge URL and validation mode.
        /// </summary>
        public OrderTransactionSecurity TransactionSecurity { get; set; }

        /// <summary>
        /// End-to-end identifier for PIX transfers, used for reconciliation with the Brazilian Central Bank.
        /// </summary>
        public string E2eId { get; set; }

        /// <summary>
        /// URL to which the payer should be redirected to complete an external authentication or payment flow.
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}
