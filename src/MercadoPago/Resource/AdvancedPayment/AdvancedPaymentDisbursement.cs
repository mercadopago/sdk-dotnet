namespace MercadoPago.Resource.AdvancedPayment
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents a disbursement within an <see cref="AdvancedPayment"/>, detailing how funds
    /// are distributed to a specific seller (receiver) in a split payment scenario.
    /// </summary>
    public class AdvancedPaymentDisbursement : IResource
    {
        /// <summary>
        /// Unique identifier of the disbursement, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Amount to be disbursed to the seller, in the transaction currency.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// External reference ID assigned by the seller in their own system.
        /// Used to reconcile the disbursement with the seller's internal records.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// MercadoPago user ID of the seller (collector) who receives this disbursement.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Marketplace fee amount charged by the application owner on this disbursement.
        /// Deducted from the seller's portion of the payment.
        /// </summary>
        public decimal? ApplicationFee { get; set; }

        /// <summary>
        /// Number of days after payment approval before funds are released to the seller.
        /// Used to configure a hold period on the disbursement.
        /// </summary>
        public int? MoneyReleaseDays { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
