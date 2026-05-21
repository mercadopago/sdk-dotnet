namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a paginated API response that uses the <c>elements</c> /
    /// <c>next_offset</c> pagination model. Some MercadoPago search endpoints
    /// (for example, authorized-payment searches) return results in this
    /// format. To fetch the next page, pass <see cref="NextOffset"/> as the
    /// <c>offset</c> query parameter in the subsequent request.
    /// </summary>
    /// <typeparam name="TResource">The type of resource contained in the page.</typeparam>
    public class ElementsResourcesPage<TResource> : IResourcesPage<TResource>
        where TResource : IResource, new()
    {
        /// <summary>
        /// Total number of resources that match the search criteria across all pages.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Offset value to request the next page of results. Pass this value as
        /// the <c>offset</c> query parameter in your next search call.
        /// </summary>
        public int NextOffset { get; set; }

        /// <summary>
        /// Collection of resources returned in the current page.
        /// </summary>
        public IList<TResource> Elements { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this page request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
