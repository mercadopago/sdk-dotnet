namespace MercadoPago.Resource
{
    /// <summary>
    /// Interface for resources page results from APIs.
    /// </summary>
    /// <typeparam name="TResouce">The type of resource searched.</typeparam>
    public interface IResourcesPage<TResouce> : IResource
        where TResouce : IResource, new()
    {
    }
}
