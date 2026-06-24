using System.Collections.Generic;
using MercadoPago.Client.Common;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration for the online checkout experience, including redirect URLs after payment,
    /// differential pricing, and 3-D Secure transaction security settings.
    /// </summary>
    /// <seealso cref="OrderConfigRequest"/>
    public class OrderOnlineConfigRequest
    {
        /// <summary>
        /// Date and time from which the order is available for payment.
        /// </summary>
        public string AvailableFrom { get; set; }

        /// <summary>
        /// Restricts which users can pay the order (e.g., "account_only").
        /// </summary>
        public string AllowedUserType { get; set; }

        /// <summary>
        /// URL that receives server-to-server notifications about the payment result.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// URL where the payer is redirected after a successful payment.
        /// </summary>
        public string SuccessUrl { get; set; }

        /// <summary>
        /// URL where the payer is redirected when the payment status is pending.
        /// </summary>
        public string PendingUrl { get; set; }

        /// <summary>
        /// URL where the payer is redirected after a failed payment.
        /// </summary>
        public string FailureUrl { get; set; }

        /// <summary>
        /// URL to which the payer is automatically returned after completing the checkout flow.
        /// </summary>
        public string AutoReturnUrl { get; set; }

        /// <summary>
        /// Controls automatic redirect behavior after payment (e.g., "approved" or "all").
        /// </summary>
        public string AutoReturn { get; set; }

        /// <summary>
        /// Tracking pixel configuration for the Checkout Pro flow.
        /// </summary>
        /// <seealso cref="OrderTrackRequest"/>
        public IList<OrderTrackRequest> Tracks { get; set; }

        /// <summary>
        /// Differential pricing configuration that allows offering different prices
        /// depending on the payment method selected by the payer.
        /// </summary>
        public DifferentialPricingRequest DifferentialPricing { get; set; }

        /// <summary>
        /// 3-D Secure transaction security configuration, controlling when authentication
        /// is required and liability shift behavior.
        /// </summary>
        /// <seealso cref="OrderTransactionSecurityRequest"/>
        public OrderTransactionSecurityRequest TransactionSecurity { get; set; }
    }
}
