namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Describes an individual item within a merchant order.
    /// Used in <see cref="MerchantOrderCreateRequest"/> and <see cref="MerchantOrderUpdateRequest"/>.
    /// </summary>
    public class MerchantOrderItemRequest
    {
        /// <summary>
        /// Item code or SKU in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Short display name of the item shown to the buyer.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fully qualified URL of the item's image.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Identifier of the item's category in the merchant's or MercadoPago's category taxonomy.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Number of units of this item in the order. Must be greater than zero.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the item in the specified currency.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the item price (e.g., <c>"ARS"</c>, <c>"BRL"</c>, <c>"USD"</c>).
        /// </summary>
        public string CurrencyId { get; set; }
    }
}
