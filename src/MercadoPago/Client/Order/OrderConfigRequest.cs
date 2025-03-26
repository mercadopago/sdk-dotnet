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
