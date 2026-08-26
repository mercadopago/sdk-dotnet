namespace MercadoPago.Client.Customer
{
    /// <summary>
    /// Request DTO for saving a new card to a customer profile.
    /// Used with <see cref="CustomerCardClient.CreateAsync"/> and <see cref="CustomerClient.CreateCardAsync"/>.
    /// The card data itself is represented by a previously generated card token.
    /// </summary>
    public class CustomerCardCreateRequest
    {
        /// <summary>
        /// A single-use card token obtained from the MercadoPago Card Token API
        /// (see <see cref="CardToken.CardTokenClient"/>). The token securely references
        /// the card data to be stored on the customer profile.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Identifier of the card issuer associated with the token.
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Identifier of the payment method associated with the token.
        /// </summary>
        public string PaymentMethodId { get; set; }
    }
}
