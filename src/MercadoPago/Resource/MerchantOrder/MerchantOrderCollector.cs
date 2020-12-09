namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Seller information from Merchant Order.
    /// </summary>
    public class MerchantOrderCollector
    {
        /// <summary>
        /// Collector ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Collector nickname.
        /// </summary>
        public string Nickname { get; set; }
    }
}
