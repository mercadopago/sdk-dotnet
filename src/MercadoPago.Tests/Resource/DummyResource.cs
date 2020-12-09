namespace MercadoPago.Tests.Resource
{
    using MercadoPago.Http;
    using MercadoPago.Resource;

    /// <summary>
    /// Dummy resources for tests.
    /// </summary>
    public class DummyResource : IResource
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
