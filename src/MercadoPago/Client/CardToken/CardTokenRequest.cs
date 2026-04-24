namespace MercadoPago.Client.CardToken
{
    /// <summary>
    /// Request DTO for creating a card token from a previously saved customer card.
    /// Used with <see cref="CardTokenClient.CreateAsync"/> and <see cref="CardTokenClient.Create"/>
    /// to generate a single-use token that can be submitted as the <c>token</c> field in a payment request.
    /// </summary>
    public class CardTokenRequest
    {
        /// <summary>
        /// Identifier of the saved card (returned when the card was stored via
        /// <see cref="Customer.CustomerCardClient"/>).
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Identifier of the customer who owns the card, as returned by
        /// <see cref="Customer.CustomerClient.CreateAsync"/>.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Card security code (CVV/CVC) required to authorize the token creation.
        /// </summary>
        public string SecurityCode { get; set; }
    }
}
