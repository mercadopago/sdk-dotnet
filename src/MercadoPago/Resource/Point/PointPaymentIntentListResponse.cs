namespace MercadoPago.Resource.Point
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents the list of payment intent events returned by
    /// <c>GET /point/integration-api/payment-intents/events</c>.
    /// </summary>
    public class PointPaymentIntentListResponse : IResource
    {
        /// <summary>
        /// Collection of payment intent events matching the requested date range.
        /// </summary>
        public IList<PointPaymentIntentEvent> Events { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
