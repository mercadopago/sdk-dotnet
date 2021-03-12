namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Search page that contains <c>results</c> property.
    /// </summary>
    /// <typeparam name="TResource">The type of resource searched.</typeparam>
    public class ResultsResourcesPage<TResource> : IResourcesPage<TResource>
        where TResource : IResource, new()
    {
        /// <summary>
        /// Paging information.
        /// </summary>
        public ResultsPaging Paging { get; set; }

        /// <summary>
        /// Items in this page.
        /// </summary>
        public IList<TResource> Results { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
