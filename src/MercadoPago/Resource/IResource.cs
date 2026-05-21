namespace MercadoPago.Resource
{
    using MercadoPago.Http;

    /// <summary>
    /// Base contract for all MercadoPago API resource models. Every class that
    /// represents a deserialized API response implements this interface so that
    /// the raw <see cref="MercadoPagoResponse"/> (HTTP status, headers, body)
    /// is always accessible alongside the typed data.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource. Useful for inspecting status codes,
        /// headers, and the original JSON body.
        /// </summary>
        MercadoPagoResponse ApiResponse { get; set; }
    }
}
