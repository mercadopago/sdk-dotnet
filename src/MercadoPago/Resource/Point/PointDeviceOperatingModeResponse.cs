namespace MercadoPago.Resource.Point
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents the response returned after changing a Point device's operating mode
    /// via <c>PATCH /point/integration-api/devices/{device_id}</c>.
    /// </summary>
    public class PointDeviceOperatingModeResponse : IResource
    {
        /// <summary>
        /// The new operating mode applied to the device (e.g. <c>PDV</c>, <c>STANDALONE</c>).
        /// </summary>
        public string OperatingMode { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
