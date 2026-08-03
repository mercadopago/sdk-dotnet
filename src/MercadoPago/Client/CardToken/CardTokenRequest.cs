namespace MercadoPago.Client.CardToken
{
    using Newtonsoft.Json;

    /// <summary>
    /// Request DTO for creating a card token. Supports two use cases:
    /// (1) from a previously saved customer card — set <see cref="CardId"/>, <see cref="CustomerId"/>, and <see cref="SecurityCode"/>;
    /// (2) from raw card data — set <see cref="CardNumber"/>, <see cref="ExpirationMonth"/>, <see cref="ExpirationYear"/>,
    /// <see cref="SecurityCode"/>, and <see cref="Cardholder"/>.
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

        /// <summary>
        /// Full card number. Used when creating a token from raw card data.
        /// </summary>
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Card expiration month (1–12). Used when creating a token from raw card data.
        /// </summary>
        [JsonProperty("expiration_month")]
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Card expiration year (four-digit). Used when creating a token from raw card data.
        /// </summary>
        [JsonProperty("expiration_year")]
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Cardholder name and identification. Used when creating a token from raw card data.
        /// </summary>
        [JsonProperty("cardholder")]
        public CustomerCardCardholderRequest Cardholder { get; set; }
    }
}
