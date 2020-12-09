namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Disbursement data.
    /// </summary>
    public class AdvancedPaymentDisbursementRequest
    {
        /// <summary>
        /// Amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Identification in seller system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Seller identification.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Collected fee.
        /// </summary>
        public decimal? ApplicationFee { get; set; }

        /// <summary>
        /// Number of days (from the payment approval date) that the payment
        /// will be released to the seller.
        /// </summary>
        public int? MoneyReleaseDays { get; set; }
    }
}
