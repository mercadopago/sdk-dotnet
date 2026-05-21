namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// State or province component of a shipping receiver address within a merchant order.
    /// </summary>
    /// <see cref="MerchantOrderReceiverAddressRequest"/>
    public class MerchantOrderReceiverAddressStateRequest
    {
        /// <summary>
        /// MercadoPago internal identifier for the state or province.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name of the state or province.
        /// </summary>
        public string Name { get; set; }
    }
}
