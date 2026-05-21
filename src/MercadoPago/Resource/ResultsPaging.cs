namespace MercadoPago.Resource
{
    /// <summary>
    /// Pagination metadata returned inside a
    /// <see cref="ResultsResourcesPage{TResource}"/>. Use these values to
    /// calculate whether more pages exist and to request them by adjusting the
    /// <c>offset</c> and <c>limit</c> query parameters.
    /// </summary>
    public class ResultsPaging
    {
        /// <summary>
        /// Total number of resources that match the search criteria across all pages.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Maximum number of resources returned per page (page size).
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Zero-based offset of the first resource in the current page
        /// relative to the full result set.
        /// </summary>
        public int Offset { get; set; }
    }
}
