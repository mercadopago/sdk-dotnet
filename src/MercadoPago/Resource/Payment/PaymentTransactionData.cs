namespace MercadoPago.Resource.Payment
{
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
        /// Transaction ID.
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
        /// Bank info.
        /// </summary>
        public PaymentBankInfo BankInfo { get; set; }
    }
}
