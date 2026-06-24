// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Automatic payment retry configuration for the online checkout flow.
    /// </summary>
    /// <seealso cref="OrderOnlineConfig"/>
    public class OrderOnlineRetries
    {
        /// <summary>
        /// Indicates whether automatic payment retry is enabled for this order.
        /// </summary>
        public bool? Allowed { get; set; }
    }
}
