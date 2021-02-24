namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Transaction data
    /// </summary>
    public class TransactionData
    {
        /// <summary>
        /// QR code
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// QR code image (Base64)
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Bank transfer ID
        /// </summary>
        public long? BankTransferId { get; set; }

        /// <summary>
        /// Financial Institution
        /// </summary>
        public long? FinancialInstitution { get; set; }

        /// <summary>
        /// Bank info
        /// </summary>
        public BankInfo BankInfo { get; set; }
    }
}
