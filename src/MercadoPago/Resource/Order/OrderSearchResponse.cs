namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents the paginated response from the MercadoPago Orders search API, containing
    /// a list of <see cref="Order"/> results and <see cref="OrderPaging"/> metadata.
    /// </summary>
    public class OrderSearchResponse : IResource
    {
        /// <summary>
        /// List of <see cref="Order"/> records matching the search criteria for the current page.
        /// </summary>
        public IList<Order> Data { get; set; }

        /// <summary>
        /// Pagination metadata including total results, page count, offset, and limit.
        /// See <see cref="OrderPaging"/>.
        /// </summary>
        public OrderPaging Paging { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
