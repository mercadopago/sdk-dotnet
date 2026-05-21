namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Represents a single disbursement (fund distribution) to a seller within an advanced payment.
    /// Each disbursement defines how much of the total payment amount goes to a specific receiver.
    /// </summary>
    /// <see cref="AdvancedPaymentCreateRequest"/>
    public class AdvancedPaymentDisbursementRequest
    {
        /// <summary>
        /// Amount to be disbursed to the seller, in the payment currency. Must be greater than zero.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Reference identifier in the seller's own system, used for reconciliation.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// MercadoPago user ID of the seller who will receive the disbursed funds.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Marketplace fee amount deducted from this disbursement and retained by the application owner.
        /// </summary>
        public decimal? ApplicationFee { get; set; }

        /// <summary>
        /// Number of days after payment approval before funds are released to the seller.
        /// A value of 0 means immediate release upon approval.
        /// </summary>
        public int? MoneyReleaseDays { get; set; }
    }
}
