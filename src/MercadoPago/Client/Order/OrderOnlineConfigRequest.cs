using MercadoPago.Client.Common;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration class.
    /// </summary>
    public class OrderOnlineConfigRequest
    {
        /// <summary>
        /// Callback URL.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Success URL.
        /// </summary>
        public string SuccessUrl { get; set; }

        /// <summary>
        /// Pending URL.
        /// </summary>
        public string PendingUrl { get; set; }

        /// <summary>
        /// Failure URL.
        /// </summary>
        public string FailureUrl { get; set; }

        /// <summary>
        /// Auto return URL.
        /// </summary>
        public string AutoReturnUrl { get; set; }

        /// <summary>
        /// Differential pricing.
        /// </summary>
        public DifferentialPricingRequest DifferentialPricing { get; set; }
    }
}
