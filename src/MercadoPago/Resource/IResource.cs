namespace MercadoPago.Resource
{
    using MercadoPago.Http;

    /// <summary>
    /// Interface for API resources.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Response from API.
        /// </summary>
        MercadoPagoResponse ApiResponse { get; set; }
    }
}
