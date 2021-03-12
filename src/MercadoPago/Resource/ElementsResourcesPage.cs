namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Search page that contains <c>elements</c> property.
    /// </summary>
    /// <typeparam name="TResource">The type of resource searched.</typeparam>
    public class ElementsResourcesPage<TResource> : IResourcesPage<TResource>
        where TResource : IResource, new()
    {
        /// <summary>
        /// The total number of items that match search criteria.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Offset of the next page.
        /// </summary>
        public int NextOffset { get; set; }

        /// <summary>
        /// Items in this page.
        /// </summary>
        public IList<TResource> Elements { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
