using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Online checkout configuration returned for an order.
    /// </summary>
    /// <seealso cref="OrderConfig"/>
    public class OrderOnlineConfig
    {
        /// <summary>
        /// URL the payer is redirected to after completing or abandoning the Checkout Pro flow.
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
        /// Date and time from which the order is available for payment.
        /// </summary>
        public string AvailableFrom { get; set; }

        /// <summary>
        /// Controls automatic redirect behavior after payment.
        /// </summary>
        public string AutoReturn { get; set; }

        /// <summary>
        /// Automatic retry configuration for the online checkout flow.
        /// </summary>
        /// <seealso cref="OrderOnlineRetries"/>
        public OrderOnlineRetries Retries { get; set; }

        /// <summary>
        /// Tracking pixel configuration returned for the Checkout Pro flow.
        /// </summary>
        /// <seealso cref="OrderTrack"/>
        public IList<OrderTrack> Tracks { get; set; }
    }
}
