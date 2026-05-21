namespace MercadoPago.Resource
{
    /// <summary>
    /// Base contract for paginated API responses. Implementations carry a
    /// collection of <typeparamref name="TResource"/> items together with
    /// pagination metadata. The two built-in implementations are
    /// <see cref="ElementsResourcesPage{TResource}"/> (uses an <c>elements</c>
    /// array with a <c>next_offset</c>) and
    /// <see cref="ResultsResourcesPage{TResource}"/> (uses a <c>results</c>
    /// array with a <see cref="ResultsPaging"/> object).
    /// </summary>
    /// <typeparam name="TResource">The type of resource contained in the page.</typeparam>
    public interface IResourcesPage<TResource> : IResource
        where TResource : IResource, new()
    {
    }
}
