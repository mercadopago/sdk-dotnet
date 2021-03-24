namespace MercadoPago.Resource
{
    /// <summary>
    /// Paging section of <see cref="ResultsResourcesPage{TResource}"/>.
    /// </summary>
    public class ResultsPaging
    {
        /// <summary>
        /// The total number of items that match search criteria.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Limit of items in this page.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Current page offset.
        /// </summary>
        public int Offset { get; set; }
    }
}
