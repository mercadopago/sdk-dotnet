namespace MercadoPago.DataStructures.Payment
{
    /// <summary>
    /// Merchant services
    /// </summary>
    public class MerchantServices
    {
        /// <summary>
        /// Fraud scoring?
        /// </summary>
        public bool? FraudScoring { get; set; }

        /// <summary>
        /// Fraud manual review?
        /// </summary>
        public bool? FraudManualReview { get; set; }
    }
}
