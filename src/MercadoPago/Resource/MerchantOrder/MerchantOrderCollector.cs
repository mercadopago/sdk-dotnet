namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the seller (collector) who owns a <see cref="MerchantOrder"/>.
    /// Contains the seller's MercadoPago account identification.
    /// </summary>
    public class MerchantOrderCollector
    {
        /// <summary>
        /// Unique MercadoPago user ID of the seller (collector).
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Display nickname of the seller on the MercadoPago platform.
        /// </summary>
        public string Nickname { get; set; }
    }
}
