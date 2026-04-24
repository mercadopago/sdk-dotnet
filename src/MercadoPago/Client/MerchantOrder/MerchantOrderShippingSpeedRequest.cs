namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Handling and transit time breakdown for a merchant order shipping option.
    /// </summary>
    /// <see cref="MerchantOrderShippingOptionRequest"/>
    public class MerchantOrderShippingSpeedRequest
    {
        /// <summary>
        /// Handling time in hours before the package is handed to the carrier.
        /// </summary>
        public long? Handling { get; set; }

        /// <summary>
        /// Transit time in hours from carrier pick-up to delivery.
        /// </summary>
        public long? Shipping { get; set; }
    }
}
