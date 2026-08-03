namespace MercadoPago.Resource.Point
{
    using System.Collections.Generic;
    using MercadoPago.Http;
    using MercadoPago.Resource;

    /// <summary>
    /// Represents the paginated list of Point devices returned by
    /// <c>GET /point/integration-api/devices</c>.
    /// </summary>
    public class PointDevicesResponse : IResource
    {
        /// <summary>
        /// List of Point devices associated with the authenticated account.
        /// </summary>
        public IList<PointDevice> Devices { get; set; }

        /// <summary>
        /// Pagination metadata for the device list.
        /// </summary>
        public ResultsPaging Paging { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
