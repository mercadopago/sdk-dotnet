// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Items class.
    /// </summary>
    public class OrderItems
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
        /// Description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Category Id of the item.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Type of the item.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Picture URL of the item.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Quantity of the item.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Warranty of the item.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Event date of the item.
        /// </summary>
        public string EventDate { get; set; }
    }
}
