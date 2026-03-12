namespace MercadoPago.Client.Order
{
    /// <summary>
    /// OrderSearchRequest class.
    /// </summary>
    public class OrderSearchRequest
    {
        /// <summary>
        /// Begin date (RFC3339).
        /// </summary>
        public string BeginDate { get; set; }

        /// <summary>
        /// End date (RFC3339).
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// External reference filter.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Type filter.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Status filter.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status detail filter.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Payment method ID filter.
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method type filter.
        /// </summary>
        public string PaymentMethodType { get; set; }

        /// <summary>
        /// Page number.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Sort by field.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Sort order.
        /// </summary>
        public string SortOrder { get; set; }
    }
}
