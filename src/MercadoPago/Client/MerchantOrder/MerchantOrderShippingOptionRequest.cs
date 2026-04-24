namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Describes the selected shipping option for a merchant order shipment, including
    /// cost, carrier, estimated delivery, and speed details.
    /// </summary>
    /// <see cref="MerchantOrderShipmentRequest"/>
    public class MerchantOrderShippingOptionRequest
    {
        /// <summary>
        /// Unique identifier of this shipping option.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Net shipping cost absorbed by the buyer, in the specified currency.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// ISO 4217 currency code for shipping costs (e.g., <c>"ARS"</c>, <c>"BRL"</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Estimated delivery date and time window for this shipping option.
        /// </summary>
        /// <see cref="MerchantOrderShippingEstimatedDeliveryRequest"/>
        public MerchantOrderShippingEstimatedDeliveryRequest EstimatedDelivery { get; set; }

        /// <summary>
        /// Listed (catalog) shipping cost before any discounts or promotions.
        /// </summary>
        public decimal? ListCost { get; set; }

        /// <summary>
        /// Display name of the shipping option (e.g., <c>"Standard"</c>, <c>"Express"</c>).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the shipping carrier or method.
        /// </summary>
        public long? ShippingMethodId { get; set; }

        /// <summary>
        /// Handling and transit speed details for this shipping option.
        /// </summary>
        /// <see cref="MerchantOrderShippingSpeedRequest"/>
        public MerchantOrderShippingSpeedRequest Speed { get; set; }
    }
}
