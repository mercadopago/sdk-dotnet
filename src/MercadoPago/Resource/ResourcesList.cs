namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// List of resources.
    /// </summary>
    /// <typeparam name="TResource">The type of resource listed.</typeparam>
    public class ResourcesList<TResource> : List<TResource>, IResource
        where TResource : IResource, new()
    {
        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
