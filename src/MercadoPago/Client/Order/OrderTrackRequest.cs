using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Tracking pixel configuration for an online checkout flow.
    /// </summary>
    /// <seealso cref="OrderOnlineConfigRequest"/>
    public class OrderTrackRequest
    {
        /// <summary>
        /// Tracking pixel type (e.g., "google_ad" or "facebook_ad").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tracking pixel values required by the selected type.
        /// </summary>
        public IDictionary<string, string> Values { get; set; }
    }
}
