using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Point of Interaction information.
    /// </summary>
    public class PaymentPointOfInteractionRequest
    {
        /// <summary>
        /// Linked To.
        /// </summary>
        public string LinkedTo { get; set; }
    }
}
