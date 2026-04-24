namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Details of a purchased item within <see cref="PaymentAdditionalInfoRequest"/>.
    /// Each item represents a product or service being paid for in the transaction.
    /// </summary>
    public class PaymentItemRequest
    {
        /// <summary>
        /// Item code or SKU in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item name or title displayed to the payer.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item's image for display purposes.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// MercadoPago category identifier for the item (e.g., "electronics", "clothing").
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Quantity of this item being purchased.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Unit price of a single item.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Category-specific descriptor providing additional context, such as
        /// passenger and flight route information for travel items.
        /// </summary>
        /// <seealso cref="PaymentCategoryDescriptorRequest"/>
        public PaymentCategoryDescriptorRequest CategoryDescriptor { get; set; }

        /// <summary>
        /// <c>true</c> if the item is purchased with a warranty; otherwise, <c>false</c>.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Date of the event associated with the item (e.g., concert date, flight date).
        /// </summary>
        public DateTime? EventDate { get; set; }
    }
}
