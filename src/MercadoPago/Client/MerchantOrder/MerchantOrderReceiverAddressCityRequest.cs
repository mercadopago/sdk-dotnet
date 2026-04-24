namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// City component of a shipping receiver address within a merchant order.
    /// </summary>
    /// <see cref="MerchantOrderReceiverAddressRequest"/>
    public class MerchantOrderReceiverAddressCityRequest
    {
        /// <summary>
        /// MercadoPago internal identifier for the city.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name of the city.
        /// </summary>
        public string Name { get; set; }
    }
}
