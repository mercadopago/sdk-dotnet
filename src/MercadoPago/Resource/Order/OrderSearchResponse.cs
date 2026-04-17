namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// OrderSearchResponse class.
    /// </summary>
    public class OrderSearchResponse : IResource
    {
        /// <summary>
        /// List of orders.
        /// </summary>
        public IList<Order> Data { get; set; }

        /// <summary>
        /// Paging information.
        /// </summary>
        public OrderPaging Paging { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
