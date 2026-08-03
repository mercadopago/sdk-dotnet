namespace MercadoPago.Resource.Point
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents the status events for a specific payment intent returned by
    /// <c>GET /point/integration-api/payment-intents/{payment_intent_id}/events</c>.
    /// </summary>
    public class PointPaymentIntentStatusResponse : IResource
    {
        /// <summary>
        /// Identifier of the payment intent whose status history is returned.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ordered list of status-change events for the payment intent.
        /// </summary>
        public IList<PointPaymentIntentEvent> Events { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
