namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Describes an individual item being purchased as part of an advanced payment.
    /// Included in the additional information section to enhance fraud analysis.
    /// </summary>
    /// <see cref="AdvancedPaymentAdditionalInfoRequest"/>
    public class AdvancedPaymentItemRequest
    {
        /// <summary>
        /// Item code or SKU in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Short display name of the item.
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
        /// Number of units of this item being purchased. Must be greater than zero.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the item in the payment currency.
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}
