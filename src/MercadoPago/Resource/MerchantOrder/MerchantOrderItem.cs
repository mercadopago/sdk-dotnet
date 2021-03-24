namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Item information.
    /// </summary>
    public class MerchantOrderItem
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
        /// Currency ID. ISO_4217 code.
        /// </summary>
        public string CurrencyId { get; set; }
    }
}
