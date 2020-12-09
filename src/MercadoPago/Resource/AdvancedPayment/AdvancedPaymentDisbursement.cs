namespace MercadoPago.Resource.AdvancedPayment
{
    using MercadoPago.Http;

    /// <summary>
    /// Disbursement data.
    /// </summary>
    public class AdvancedPaymentDisbursement : IResource
    {
        /// <summary>
        /// Disbursement ID.
        /// </summary>
        public long? Id { get; set; }

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

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
