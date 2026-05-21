namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Represents an individual item being purchased in a payment.
    /// Included in the <see cref="PaymentAdditionalInfo.Items"/> list
    /// to improve fraud analysis and provide purchase details.
    /// </summary>
    public class PaymentItem
    {
        /// <summary>
        /// Item code or SKU identifier in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Short name or title of the item being purchased.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item, providing additional context
        /// about the product or service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item's image. Used for display in payment receipts
        /// and checkout flows.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category identifier of the item in the merchant's catalog
        /// (e.g., "electronics", "clothing").
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Number of units of this item being purchased.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of this item in the payment's currency.
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}
