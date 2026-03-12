namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// OrderPaging class.
    /// </summary>
    public class OrderPaging
    {
        /// <summary>
        /// Total.
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// Total pages.
        /// </summary>
        public string TotalPages { get; set; }

        /// <summary>
        /// Offset.
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Limit.
        /// </summary>
        public string Limit { get; set; }
    }
}
