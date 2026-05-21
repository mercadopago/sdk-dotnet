namespace MercadoPago.Resource.AdvancedPayment
{
    /// <summary>
    /// Represents a purchased item included in the <see cref="AdvancedPaymentAdditionalInfo"/>
    /// of an <see cref="AdvancedPayment"/>. Provides product details used for fraud prevention
    /// and transaction enrichment.
    /// </summary>
    public class AdvancedPaymentItem
    {
        /// <summary>
        /// Item code or SKU that uniquely identifies the product in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the item shown to the payer.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item, providing additional product information.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item's image. Used for display in the checkout flow.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category identifier of the item within the merchant's product taxonomy.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Number of units of this item being purchased.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the item, in the transaction currency.
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}
