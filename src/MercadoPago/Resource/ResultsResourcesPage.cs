namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a paginated API response that uses the <c>results</c> /
    /// <c>paging</c> pagination model. Most MercadoPago search endpoints
    /// (for example, payment and customer searches) return results in this
    /// format. Inspect <see cref="Paging"/> to determine whether additional
    /// pages are available.
    /// </summary>
    /// <typeparam name="TResource">The type of resource contained in the page.</typeparam>
    public class ResultsResourcesPage<TResource> : IResourcesPage<TResource>
        where TResource : IResource, new()
    {
        /// <summary>
        /// Pagination metadata including total count, current offset, and page
        /// size. Use these values to calculate and request subsequent pages.
        /// </summary>
        public ResultsPaging Paging { get; set; }

        /// <summary>
        /// Collection of resources returned in the current page.
        /// </summary>
        public IList<TResource> Results { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this page request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
