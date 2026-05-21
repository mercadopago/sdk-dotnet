namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the city component of a <see cref="MerchantOrderReceiverAddress"/>
    /// within a merchant order shipment.
    /// </summary>
    public class MerchantOrderReceiverAddressCity
    {
        /// <summary>
        /// MercadoPago internal identifier for the city.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the city (e.g., "Buenos Aires", "Sao Paulo").
        /// </summary>
        public string Name { get; set; }
    }
}
