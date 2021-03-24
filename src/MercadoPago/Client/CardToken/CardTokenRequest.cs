namespace MercadoPago.Client.CardToken
{
    /// <summary>
    /// Data to create the card token.
    /// </summary>
    public class CardTokenRequest
    {
        /// <summary>
        /// Card ID.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Card security code.
        /// </summary>
        public string SecurityCode { get; set; }
    }
}
