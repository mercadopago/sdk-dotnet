namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Purchased item.
    /// </summary>
    public class PaymentItemRequest
    {
        /// <summary>
        /// Item code.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Long item description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image URL.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category of the item.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Item's quantity.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Item information related to the category.
        /// </summary>
        public PaymentCategoryDescriptorRequest CategoryDescriptor { get; set; }

        /// <summary>
        /// <c>true</c> if you purchase the item with warranty, <c>false</c>
        /// if not.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Event date.
        /// </summary>
        public DateTime? EventDate { get; set; }
    }
}
