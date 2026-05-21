namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents pagination metadata in an <see cref="OrderSearchResponse"/>, providing information
    /// to navigate through paginated order search results.
    /// </summary>
    public class OrderPaging
    {
        /// <summary>
        /// Total number of orders matching the search criteria across all pages.
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// Total number of pages available based on the current <see cref="Limit"/> setting.
        /// </summary>
        public string TotalPages { get; set; }

        /// <summary>
        /// Zero-based offset of the first result in the current page within the full result set.
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Maximum number of order records returned per page.
        /// </summary>
        public string Limit { get; set; }
    }
}
