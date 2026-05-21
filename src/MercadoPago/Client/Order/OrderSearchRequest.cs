namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Query parameters for searching orders via <c>GET /v1/orders</c>.
    /// Supports filtering by date range, status, payment method, and external reference,
    /// with pagination and sorting controls.
    /// </summary>
    /// <seealso cref="OrderClient.Search(OrderSearchRequest, RequestOptions)"/>
    /// <seealso cref="OrderClient.SearchAsync(OrderSearchRequest, RequestOptions, System.Threading.CancellationToken)"/>
    public class OrderSearchRequest
    {
        /// <summary>
        /// Start of the date range filter in RFC 3339 format (e.g., "2024-01-01T00:00:00Z").
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// End of the date range filter in RFC 3339 format (e.g., "2024-12-31T23:59:59Z").
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Filters results by the external reference assigned when the order was created.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Filters results by order type (e.g., "online").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Filters results by order status (e.g., "processed", "canceled", "refunded").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Filters results by status detail for more granular status matching.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Filters results by payment method identifier (e.g., "visa", "pix").
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Filters results by payment method type (e.g., "credit_card", "bank_transfer").
        /// </summary>
        public string PaymentMethodType { get; set; }

        /// <summary>
        /// Zero-based page number for paginated results.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Number of results per page.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Field name used to sort the results (e.g., "date_created").
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Sort direction: "asc" for ascending or "desc" for descending.
        /// </summary>
        public string SortOrder { get; set; }
    }
}
