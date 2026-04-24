namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents a product or service item within a <see cref="MerchantOrder"/>.
    /// Contains details such as title, description, pricing, and quantity.
    /// </summary>
    public class MerchantOrderItem
    {
        /// <summary>
        /// Item code or SKU that uniquely identifies the product in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the item shown to the buyer.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item, providing additional product information beyond the title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item's image, used for display in the checkout and order summary.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category identifier of the item within the merchant's product taxonomy.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Number of units of this item included in the order.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the item, in the currency specified by <see cref="CurrencyId"/>.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the item price (e.g., <c>ARS</c>, <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }
    }
}
