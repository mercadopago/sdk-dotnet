namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the selected shipping option for a <see cref="MerchantOrderShipment"/>,
    /// including cost, delivery estimate, and speed details.
    /// </summary>
    public class MerchantOrderShippingOption
    {
        /// <summary>
        /// Unique identifier of the shipping option.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Net shipping cost absorbed by the buyer, in the currency specified by <see cref="CurrencyId"/>.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the shipping cost (e.g., <c>ARS</c>, <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Estimated delivery date and time window for this shipping option.
        /// </summary>
        public MerchantOrderShippingEstimatedDelivery EstimatedDelivery { get; set; }

        /// <summary>
        /// Listed (base) cost of the shipping before any discounts or promotions are applied.
        /// </summary>
        public decimal? ListCost { get; set; }

        /// <summary>
        /// Display name of the shipping option (e.g., "Standard", "Express").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the shipping method used by the carrier.
        /// </summary>
        public long? ShippingMethodId { get; set; }

        /// <summary>
        /// Handling and transit time details for this shipping option.
        /// </summary>
        public MerchantOrderShippingSpeed Speed { get; set; }
    }
}
