namespace MercadoPago.Resource
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// A strongly-typed list of <typeparamref name="TResource"/> items
    /// returned by a MercadoPago API endpoint that responds with a plain
    /// JSON array (no pagination wrapper). Because it extends
    /// <see cref="List{T}"/> you can iterate, index, and use LINQ directly.
    /// The raw API response is still available via <see cref="ApiResponse"/>.
    /// </summary>
    /// <typeparam name="TResource">The type of resource contained in the list.</typeparam>
    public class ResourcesList<TResource> : List<TResource>, IResource
        where TResource : IResource, new()
    {
        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this list request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
