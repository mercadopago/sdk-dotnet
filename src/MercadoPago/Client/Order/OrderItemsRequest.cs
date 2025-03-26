namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Items class.
    /// </summary>
    public class OrderItemsRequest
    {
        /// <summary>
        /// Title of the item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Unit price of the item.
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// Quantity of the item.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// External code of the item.
        /// </summary>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Category of the item.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Picture URL of the item.
        /// </summary>
        public string PictureUrl { get; set; }
    }
}
