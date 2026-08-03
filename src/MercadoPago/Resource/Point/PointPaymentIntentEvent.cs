namespace MercadoPago.Resource.Point
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents a single event in the lifecycle of a Point payment intent.
    /// </summary>
    public class PointPaymentIntentEvent : IResource
    {
        /// <summary>
        /// Unique identifier of the payment intent associated with this event.
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Current state of the payment intent at the time of this event.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Identifier of the Point device on which this event occurred.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
