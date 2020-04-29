namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Purchased item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Item identification
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item image URL
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Item category ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Quantity purchased
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Item unit price
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}
