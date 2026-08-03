namespace MercadoPago.Client.CardToken
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Cardholder data used when creating a card token directly from raw card fields
    /// (as opposed to using a saved customer card).
    /// </summary>
    public class CustomerCardCardholderRequest
    {
        /// <summary>
        /// Name of the cardholder exactly as it appears on the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cardholder's government-issued identification document.
        /// </summary>
        public IdentificationRequest Identification { get; set; }
    }
}
