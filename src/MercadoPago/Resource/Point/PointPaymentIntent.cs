namespace MercadoPago.Resource.Point
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents a payment intent on a MercadoPago Point device returned by
    /// the Point Integration API. A payment intent represents a transaction
    /// sent to a physical card reader for the buyer to complete. Use
    /// <see cref="Client.Point.PointClient"/> to create, retrieve, and cancel
    /// payment intents.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference/in-person-payments/point/orders/create-order/post">here</a>.
    /// </remarks>
    public class PointPaymentIntent : IResource
    {
        /// <summary>
        /// Unique identifier of this payment intent.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Current state of the payment intent (e.g. <c>OPEN</c>, <c>ON_TERMINAL</c>,
        /// <c>PROCESSED</c>, <c>CANCELLED</c>).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Identifier of the Point device to which this intent was sent.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Identifier of the MercadoPago payment generated when the buyer completes
        /// the transaction on the device. Populated only when the intent is processed.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
