namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Merchant-level service configuration for a <see cref="PaymentCreateRequest"/>.
    /// Controls optional fraud prevention services such as automated scoring and manual review.
    /// </summary>
    public class PaymentMerchantServicesRequest
    {
        /// <summary>
        /// <c>true</c> to enable automated fraud scoring for this payment;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? FraudScoring { get; set; }

        /// <summary>
        /// <c>true</c> to request manual fraud review for this payment;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? FraudManualReview { get; set; }
    }
}
