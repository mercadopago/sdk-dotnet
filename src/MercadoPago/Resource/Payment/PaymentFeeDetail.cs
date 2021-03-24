namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Fee information.
    /// </summary>
    public class PaymentFeeDetail
    {
        /// <summary>
        /// Fee type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Who absorbs the cost.
        /// </summary>
        public string FeePayer { get; set; }

        /// <summary>
        /// Fee amount.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
