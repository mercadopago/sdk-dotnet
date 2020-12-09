namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Shipping time information.
    /// </summary>
    public class MerchantOrderShippingSpeedRequest
    {
        /// <summary>
        /// Handling time.
        /// </summary>
        public long? Handling { get; set; }

        /// <summary>
        /// Shipping time.
        /// </summary>
        public long? Shipping { get; set; }
    }
}
