namespace MercadoPago.Client.Point
{
    /// <summary>
    /// Request body for creating a payment intent on a Point device
    /// via <see cref="PointClient.CreateAsync"/> / <see cref="PointClient.Create"/>.
    /// </summary>
    public class PointCreatePaymentIntentRequest
    {
        /// <summary>
        /// Total amount to charge the buyer.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Short description of the transaction shown on the device.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Payment method configuration (installments, type).
        /// </summary>
        public PointPaymentRequest Payment { get; set; }

        /// <summary>
        /// Free-text external reference for correlating this intent with your own system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Indicates whether to print a receipt on the device after payment.
        /// </summary>
        public bool? PrintOnTerminal { get; set; }
    }
}
