namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the country component of a <see cref="MerchantOrderReceiverAddress"/>
    /// within a merchant order shipment.
    /// </summary>
    public class MerchantOrderReceiverAddressCountry
    {
        /// <summary>
        /// ISO country code identifier (e.g., <c>AR</c>, <c>BR</c>, <c>MX</c>).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Full display name of the country (e.g., "Argentina", "Brasil").
        /// </summary>
        public string Name { get; set; }
    }
}
