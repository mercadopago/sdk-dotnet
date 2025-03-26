// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Payment Method class.
    /// </summary>
    public class OrderPaymentMethod
    {
        /// <summary>
        /// Payment Method ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Card ID.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Payment Method Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of installments.
        /// </summary>
        public int Installments { get; set; }

        /// <summary>
        /// Payment Method Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// How will look the payment in the card bill (e.g.: MERCADOPAGO).
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Ticket URL.
        /// </summary>
        public string TicketUrl { get; set; }

        /// <summary>
        /// Barcode Content.
        /// </summary>
        public string BarcodeContent { get; set; }

        /// <summary>
        /// Reference.
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Reference ID.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Verification Code.
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Financial Institution.
        /// </summary>
        public string FinancialInstitution { get; set; }

        /// <summary>
        /// QR Code.
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// QR Code Base64.
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// Digitable Line.
        /// </summary>
        public string DigitableLine { get; set; }
    }
}
