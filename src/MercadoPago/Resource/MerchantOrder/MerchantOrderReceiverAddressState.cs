namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the state or province component of a <see cref="MerchantOrderReceiverAddress"/>
    /// within a merchant order shipment.
    /// </summary>
    public class MerchantOrderReceiverAddressState
    {
        /// <summary>
        /// MercadoPago internal identifier for the state or province.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the state or province (e.g., "Buenos Aires", "Rio de Janeiro").
        /// </summary>
        public string Name { get; set; }
    }
}
