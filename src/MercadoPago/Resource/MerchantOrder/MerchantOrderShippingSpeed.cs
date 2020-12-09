namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Shipping time information.
    /// </summary>
    public class MerchantOrderShippingSpeed
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
