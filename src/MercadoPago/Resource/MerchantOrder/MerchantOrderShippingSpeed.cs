namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the handling and transit time breakdown for a <see cref="MerchantOrderShippingOption"/>.
    /// Values are typically expressed in hours.
    /// </summary>
    public class MerchantOrderShippingSpeed
    {
        /// <summary>
        /// Handling time in hours, representing the period from order confirmation
        /// to when the seller ships the package.
        /// </summary>
        public long? Handling { get; set; }

        /// <summary>
        /// Transit time in hours, representing the period from when the carrier
        /// picks up the package to delivery at the destination.
        /// </summary>
        public long? Shipping { get; set; }
    }
}
