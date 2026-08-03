namespace MercadoPago.Resource.Point
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents a MercadoPago Point physical card-reader device.
    /// </summary>
    public class PointDevice : IResource
    {
        /// <summary>
        /// Unique identifier of the device.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Current operating mode of the device (e.g. <c>PDV</c>, <c>STANDALONE</c>).
        /// </summary>
        public string OperatingMode { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
