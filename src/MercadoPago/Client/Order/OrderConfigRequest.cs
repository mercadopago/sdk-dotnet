// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration class.
    /// </summary>
    public class OrderConfigRequest
    {
        /// <summary>
        /// Payment method configuration.
        /// </summary>
        public OrderPaymentMethodConfigRequest PaymentMethod { get; set; }

        /// <summary>
        /// Online configuration.
        /// </summary>
        public OrderOnlineConfigRequest Online { get; set; }
    }
}
