namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Country component of a shipping receiver address within a merchant order.
    /// </summary>
    /// <see cref="MerchantOrderReceiverAddressRequest"/>
    public class MerchantOrderReceiverAddressCountryRequest
    {
        /// <summary>
        /// ISO 3166-1 country code or MercadoPago country identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name of the country.
        /// </summary>
        public string Name { get; set; }
    }
}
