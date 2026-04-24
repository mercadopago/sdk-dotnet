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
    }
}
